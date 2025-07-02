using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class PlaceholderTextBox : TextBox
{
	private string _placeholderText = "";
	private Color _placeholderColor = Color.Gray;

	[Category("Appearance")]
	[Description("The placeholder text displayed when the TextBox is empty.")]
	public string PlaceholderText
	{
		get => _placeholderText;
		set { _placeholderText = value; Invalidate(); }
	}

    [Category("Appearance")]
    [Description("The color of the placeholder text.")]
    public Color PlaceholderColor
    {
        get => _placeholderColor;
        set { _placeholderColor = value; Invalidate(); }
    }
	char pc;
    [Category("Appearance")]
    [Description("The color of the placeholder text.")]
    public char PasswordChars
    {
        get => pc;
        set { pc= value; Invalidate(); }
    }

    public PlaceholderTextBox()
	{
		// Enable double-buffering to reduce flicker
		SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
	}


	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);

		// Draw the default text box appearance
		using (var brush = new SolidBrush(BackColor))
		{
			e.Graphics.FillRectangle(brush, ClientRectangle);
		}

		// Draw the border
		//ControlPaint.DrawBorder(e.Graphics, ClientRectangle, SystemColors.ControlDark, ButtonBorderStyle.Solid);

		// Draw the text or the placeholder
		if (string.IsNullOrEmpty(Text) && !Focused && !string.IsNullOrEmpty(_placeholderText))
		{
			using (var brush = new SolidBrush(_placeholderColor))
			{
				e.Graphics.DrawString(_placeholderText, Font, brush, new PointF(1, 1));
			}
		}
		else
		{
			
			if (PasswordChars != '\0')
			{
                using (var brush = new SolidBrush(ForeColor))
                {
                    e.Graphics.DrawString(string.Concat(Text.ToCharArray().Select(x=> PasswordChars + "").ToArray()), Font, brush, new PointF(1, 1));
                }
            }
			else
			{
				using (var brush = new SolidBrush(ForeColor))
				{
					e.Graphics.DrawString(Text, Font, brush, new PointF(1, 1));
				}
			}
		}
	}

	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
		Invalidate(); // Redraw to update placeholder visibility
	}

	protected override void OnGotFocus(EventArgs e)
	{
		base.OnGotFocus(e);
		Invalidate(); // Redraw to hide placeholder
	}

	protected override void OnLostFocus(EventArgs e)
	{
		base.OnLostFocus(e);
		Invalidate(); // Redraw to show placeholder
	}
}
