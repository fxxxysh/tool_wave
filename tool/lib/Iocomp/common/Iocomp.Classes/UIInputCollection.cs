using Iocomp.Interfaces;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public class UIInputCollection : IEnumerable
	{
		private ArrayList m_List;

		private IUIInput m_MouseDownControl;

		private IUIInput m_FocusControl;

		private ControlBase m_ControlBase;

		private bool m_DragActive;

		public int Count => m_List.Count;

		public IUIInput this[int index]
		{
			get
			{
				return m_List[index] as IUIInput;
			}
		}

		private IUIInput MouseDownControl => m_MouseDownControl;

		private IUIInput FocusControl => m_FocusControl;

		private ControlBase ControlBase => m_ControlBase;

		private bool Focused => ControlBase.Focused;

		public bool DragActive => m_DragActive;

		public Cursor Cursor
		{
			get
			{
				if (ControlBase == null)
				{
					return Cursors.Default;
				}
				return ControlBase.Cursor;
			}
		}

		public UIInputCollection(ControlBase value)
		{
			if (value == null)
			{
				throw new Exception("ControlBase must be assigned");
			}
			m_ControlBase = value;
			m_List = new ArrayList();
		}

		public IEnumerator GetEnumerator()
		{
			return m_List.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public int Add(IUIInput value)
		{
			value.UICollection = this;
			value.IsMouseDown = false;
			value.IsMouseActive = false;
			value.IsKeyDown = false;
			value.IsKeyActive = false;
			return m_List.Add(value);
		}

		public void Remove(IUIInput value)
		{
			value.UICollection = null;
			m_List.Remove(value);
			if (m_FocusControl == value)
			{
				m_FocusControl = null;
				if (m_List.Count != 0)
				{
					m_FocusControl = (m_List[0] as IUIInput);
					if (Focused)
					{
						m_FocusControl.GotFocus(EventArgs.Empty);
					}
				}
			}
		}

		public void Clear()
		{
			foreach (IUIInput item in m_List)
			{
				item.UICollection = null;
			}
			m_List.Clear();
			m_FocusControl = null;
		}

		public void ClearFocus()
		{
			m_FocusControl = null;
		}

		public void Sort(IComparer comparer)
		{
			m_List.Sort(comparer);
		}

		public int IndexOf(IUIInput value)
		{
			return m_List.IndexOf(value);
		}

		public void UIInvalidate(object value)
		{
			if (m_ControlBase != null)
			{
				m_ControlBase.UIInvalidate(value);
			}
		}

		private IUIInput GetUIInputControl(MouseEventArgs e)
		{
			IUIInput result = null;
			int num = 2147483647;
			for (int i = 0; i < Count; i++)
			{
				IUIInput iUIInput = this[i];
				if (iUIInput != null && iUIInput.Enabled && iUIInput.HitVisible && iUIInput.HitTest(e))
				{
					int num2 = iUIInput.Bounds.Width * iUIInput.Bounds.Height;
					if (num2 < num)
					{
						num = num2;
						result = iUIInput;
					}
				}
			}
			return result;
		}

		public void FocusDisabled(IUIInput value)
		{
			if (FocusControl == value)
			{
				if (Focused)
				{
					FocusControl.LostFocus(new LostFocusEventArgs(null));
				}
				m_FocusControl = null;
				if (m_List.Count != 0)
				{
					m_FocusControl = (m_List[0] as IUIInput);
					if (Focused)
					{
						FocusControl.GotFocus(EventArgs.Empty);
					}
				}
			}
		}

		public void SetFocus(IUIInput value)
		{
			if (FocusControl != null && FocusControl != value)
			{
				LostFocusEventArgs lostFocusEventArgs = new LostFocusEventArgs(value);
				if (Focused)
				{
					FocusControl.LostFocus(lostFocusEventArgs);
				}
				if (!lostFocusEventArgs.Cancel)
				{
					FocusControl.IsMouseDown = false;
					FocusControl.IsMouseActive = false;
					FocusControl.IsKeyDown = false;
					FocusControl.IsKeyActive = false;
					goto IL_0065;
				}
				return;
			}
			goto IL_0065;
			IL_0065:
			m_FocusControl = value;
			if (!ControlBase.Focused)
			{
				Focus();
			}
			else
			{
				FocusControl.GotFocus(EventArgs.Empty);
				ControlBase.UIInvalidate(this);
			}
		}

		public void Focus()
		{
			if (!ControlBase.Focused)
			{
				ControlBase.Focus();
				ControlBase.UIInvalidate(this);
			}
		}

		public void StartDrag()
		{
			m_DragActive = true;
		}

		public bool GetIsFocused(IUIInput value)
		{
			if (!Focused)
			{
				return false;
			}
			return value == FocusControl;
		}

		public void MouseRight(MouseEventArgs e)
		{
			Focus();
			IUIInput uIInputControl = GetUIInputControl(e);
			if (uIInputControl != null)
			{
				uIInputControl.IsMouseDown = false;
				uIInputControl.IsMouseActive = false;
				uIInputControl.IsKeyDown = false;
				uIInputControl.IsKeyActive = false;
				uIInputControl.MouseRight(e);
			}
			ControlBase.UIInvalidate(this);
		}

		public void MouseLeft(MouseEventArgs e)
		{
			m_DragActive = false;
			Focus();
			Control controlBase = ControlBase;
			IUIInput uIInputControl = GetUIInputControl(e);
			if (uIInputControl != null)
			{
				uIInputControl.IsMouseDown = true;
				uIInputControl.IsMouseActive = false;
				uIInputControl.IsKeyDown = false;
				uIInputControl.IsKeyActive = false;
				if (controlBase != null)
				{
					controlBase.Cursor = uIInputControl.GetMouseCursor(e);
				}
				uIInputControl.MouseLeft(e, true);
			}
			m_MouseDownControl = uIInputControl;
			ControlBase.UIInvalidate(this);
		}

		public bool MouseMove(MouseEventArgs e)
		{
			Control controlBase = ControlBase;
			if (!m_DragActive && MouseDownControl != null)
			{
				if (controlBase != null)
				{
					controlBase.Cursor = MouseDownControl.GetMouseCursor(e);
				}
				MouseDownControl.MouseMove(e);
				ControlBase.UIInvalidate(this);
			}
			else
			{
				IUIInput uIInputControl = GetUIInputControl(e);
				if (uIInputControl != null)
				{
					if (controlBase != null)
					{
						controlBase.Cursor = uIInputControl.GetMouseCursor(e);
					}
					uIInputControl.MouseMove(e);
					return true;
				}
				controlBase.Cursor = Cursors.Default;
			}
			return false;
		}

		public void MouseUp(MouseEventArgs e)
		{
			if (MouseDownControl != null)
			{
				IUIInput mouseDownControl = MouseDownControl;
				mouseDownControl.MouseUp(e);
				mouseDownControl.Click(e);
				mouseDownControl.IsMouseDown = false;
				mouseDownControl.IsMouseActive = false;
				mouseDownControl.IsKeyDown = false;
				mouseDownControl.IsKeyActive = false;
				m_MouseDownControl = null;
				m_DragActive = false;
				ControlBase.UIInvalidate(this);
			}
		}

		public void DoubleClick(MouseEventArgs e)
		{
			if (MouseDownControl != null)
			{
				Point point = ControlBase.PointToClient(Control.MousePosition);
				MouseDownControl.DoubleClick(new MouseEventArgs(Control.MouseButtons, 0, point.X, point.Y, 0));
			}
		}

		public void MouseWheel(MouseEventArgs e)
		{
			if (FocusControl != null)
			{
				FocusControl.MouseWheel(e);
				ControlBase.UIInvalidate(this);
			}
		}

		public void KeyDown(KeyEventArgs e)
		{
			if (FocusControl != null)
			{
				FocusControl.IsKeyDown = true;
				FocusControl.IsKeyActive = false;
				FocusControl.KeyDown(e);
				ControlBase.UIInvalidate(this);
			}
		}

		public void KeyUp(KeyEventArgs e)
		{
			if (FocusControl != null)
			{
				FocusControl.KeyUp(e);
				FocusControl.IsKeyDown = false;
				FocusControl.IsKeyActive = false;
				ControlBase.UIInvalidate(this);
			}
		}

		public void KeyPress(KeyPressEventArgs e)
		{
			if (FocusControl != null)
			{
				FocusControl.IsKeyDown = false;
				FocusControl.IsKeyActive = false;
				FocusControl.KeyPress(e);
				ControlBase.UIInvalidate(this);
			}
		}

		public void LostFocus(EventArgs e)
		{
			if (FocusControl != null)
			{
				FocusControl.LostFocus(new LostFocusEventArgs(null));
				FocusControl.IsMouseDown = false;
				FocusControl.IsMouseActive = false;
				FocusControl.IsKeyDown = false;
				FocusControl.IsKeyActive = false;
				ControlBase.UIInvalidate(this);
			}
			if (MouseDownControl != null)
			{
				MouseDownControl.MouseUp(new MouseEventArgs(Control.MouseButtons, 0, 0, 0, 0));
				MouseDownControl.IsMouseDown = false;
				MouseDownControl.IsMouseActive = false;
				MouseDownControl.IsKeyDown = false;
				MouseDownControl.IsKeyActive = false;
				m_MouseDownControl = null;
				ControlBase.UIInvalidate(this);
			}
		}

		public void GotFocus(EventArgs e)
		{
			if (FocusControl != null)
			{
				FocusControl.GotFocus(e);
				ControlBase.UIInvalidate(this);
			}
		}
	}
}
