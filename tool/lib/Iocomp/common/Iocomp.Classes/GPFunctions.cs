using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public sealed class GPFunctions
	{
		private GPFunctions()
		{
		}

		public static bool Equals(Font font1, Font font2)
		{
			if (font1 != null && font2 == null)
			{
				return false;
			}
			if (font1 == null && font2 != null)
			{
				return false;
			}
			if (font1 == null && font2 == null)
			{
				return true;
			}
			return font1.Equals(font2);
		}

		public static bool Equals(ImageList imageList1, ImageList imageList2)
		{
			if (imageList1 != null && imageList2 == null)
			{
				return false;
			}
			if (imageList1 == null && imageList2 != null)
			{
				return false;
			}
			if (imageList1 == null && imageList2 == null)
			{
				return true;
			}
			return imageList1.Equals(imageList2);
		}
	}
}
