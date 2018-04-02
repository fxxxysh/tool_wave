using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Permissions;

namespace Iocomp.Licensing
{
	internal class CustomLicenseContext : LicenseContext
	{
		internal Hashtable savedLicenseKeys;

		public override string GetSavedLicenseKey(Type type, Assembly resourceAssembly)
		{
			if (savedLicenseKeys == null)
			{
				Uri uri = null;
				if (resourceAssembly == (Assembly)null)
				{
					string licenseFile = AppDomain.CurrentDomain.SetupInformation.LicenseFile;
					FileIOPermission fileIOPermission = new FileIOPermission(PermissionState.Unrestricted);
					fileIOPermission.Assert();
					string applicationBase = default(string);
					try
					{
						applicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
					}
					finally
					{
						CodeAccessPermission.RevertAssert();
					}
					if (licenseFile != null && applicationBase != null)
					{
						uri = new Uri(new Uri(applicationBase), licenseFile);
					}
				}
				if (uri == (Uri)null && resourceAssembly == (Assembly)null)
				{
					resourceAssembly = Assembly.GetEntryAssembly();
					if (resourceAssembly == (Assembly)null)
					{
						Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
						foreach (Assembly assembly in assemblies)
						{
							if (!(assembly is AssemblyBuilder))
							{
								string localPath = new Uri(assembly.EscapedCodeBase).LocalPath;
								localPath = new FileInfo(localPath).Name;
								Stream stream = assembly.GetManifestResourceStream(localPath + ".licenses");
								if (stream == null)
								{
									stream = CaseInsensitiveManifestResourceStreamLookup(assembly, localPath + ".licenses");
								}
								if (stream != null)
								{
									Deserialize(stream, localPath.ToUpper(CultureInfo.InvariantCulture), this);
									break;
								}
							}
						}
					}
					else
					{
						string localPath2 = new Uri(resourceAssembly.EscapedCodeBase).LocalPath;
						localPath2 = new FileInfo(localPath2).Name;
						string text = localPath2 + ".licenses";
						Stream manifestResourceStream = resourceAssembly.GetManifestResourceStream(text);
						if (manifestResourceStream == null)
						{
							string text2 = null;
							CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;
							string[] manifestResourceNames = resourceAssembly.GetManifestResourceNames();
							foreach (string text3 in manifestResourceNames)
							{
								if (compareInfo.Compare(text3, text, CompareOptions.IgnoreCase) == 0)
								{
									text2 = text3;
									break;
								}
							}
							if (text2 != null)
							{
								manifestResourceStream = resourceAssembly.GetManifestResourceStream(text2);
							}
						}
						if (manifestResourceStream != null)
						{
							Deserialize(manifestResourceStream, localPath2.ToUpper(CultureInfo.InvariantCulture), this);
						}
					}
				}
				if (uri != (Uri)null && savedLicenseKeys == null)
				{
					Stream stream2 = OpenRead(uri);
					if (stream2 != null)
					{
						string[] segments = uri.Segments;
						string text4 = segments[segments.Length - 1];
						string text5 = text4.Substring(0, text4.LastIndexOf("."));
						Deserialize(stream2, text5.ToUpper(CultureInfo.InvariantCulture), this);
					}
				}
				if (savedLicenseKeys == null)
				{
					savedLicenseKeys = new Hashtable();
				}
			}
			string value = StripVersionField(type.AssemblyQualifiedName);
			string key = type.AssemblyQualifiedName;
			foreach (object key2 in savedLicenseKeys.Keys)
			{
				string text6 = key2 as string;
				if (text6 != null)
				{
					text6 = StripVersionField(text6);
					if (text6.Equals(value))
					{
						key = (key2 as string);
						break;
					}
				}
			}
			return (string)savedLicenseKeys[key];
		}

		private Stream CaseInsensitiveManifestResourceStreamLookup(Assembly satellite, string name)
		{
			CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;
			string[] manifestResourceNames = satellite.GetManifestResourceNames();
			foreach (string text in manifestResourceNames)
			{
				if (compareInfo.Compare(text, name, CompareOptions.IgnoreCase) == 0)
				{
					name = text;
					break;
				}
			}
			return satellite.GetManifestResourceStream(name);
		}

		internal void Deserialize(Stream o, string cryptoKey, CustomLicenseContext context)
		{
			IFormatter formatter = new BinaryFormatter();
			new SecurityPermission(SecurityPermissionFlag.SerializationFormatter).PermitOnly();
			new SecurityPermission(SecurityPermissionFlag.SerializationFormatter).Assert();
			object obj = default(object);
			try
			{
				obj = formatter.Deserialize(o);
			}
			finally
			{
				CodeAccessPermission.RevertAssert();
				CodeAccessPermission.RevertPermitOnly();
			}
			if (obj is object[])
			{
				object[] array = (object[])obj;
				if (array[0] is string && (string)array[0] == cryptoKey)
				{
					context.savedLicenseKeys = (Hashtable)array[1];
				}
			}
		}

		private string StripVersionField(string typeName)
		{
			int num = typeName.IndexOf("Version=");
			if (num == -1)
			{
				return typeName;
			}
			int num2 = typeName.IndexOf(',', num + 1);
			if (num2 == -1)
			{
				num -= 2;
				return typeName.Substring(0, num);
			}
			num2 += 2;
			return typeName.Remove(num, num2 - num);
		}

		private static Stream OpenRead(Uri resourceUri)
		{
			Stream result = null;
			PermissionSet permissionSet = new PermissionSet(PermissionState.Unrestricted);
			permissionSet.Assert();
			try
			{
				result = new WebClient().OpenRead(resourceUri.ToString());
				return result;
			}
			catch (Exception)
			{
				return result;
			}
			finally
			{
				CodeAccessPermission.RevertAssert();
			}
		}
	}
}
