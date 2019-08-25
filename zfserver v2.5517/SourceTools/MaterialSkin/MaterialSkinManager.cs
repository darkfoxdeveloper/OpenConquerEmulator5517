using MaterialSkin.Controls;
using SourceTools.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MaterialSkin
{
    public static class MaterialSkinManager
    {

        //Forms to control
        private static readonly List<MaterialForm> formsToManage = new List<MaterialForm>();

        //Theme
        private static Themes theme;
        public static Themes Theme
        {
            get { return theme; }
            set
            {
                theme = value;
                UpdateBackgrounds();
            }
        }

        private static ColorScheme colorScheme;
        public static ColorScheme ColorScheme
        {
            get { return colorScheme; }
            set
            {
                colorScheme = value;
                UpdateBackgrounds();
            }
        }

        public enum Themes : byte
        {
            LIGHT,
            DARK
        }

        //Constant color values
        private static readonly Color PRIMARY_TEXT_BLACK = Color.FromArgb(222, 0, 0, 0);
        private static readonly Brush PRIMARY_TEXT_BLACK_BRUSH = new SolidBrush(PRIMARY_TEXT_BLACK);
        public static Color SECONDARY_TEXT_BLACK = Color.FromArgb(138, 0, 0, 0);
        public static Brush SECONDARY_TEXT_BLACK_BRUSH = new SolidBrush(SECONDARY_TEXT_BLACK);
        private static readonly Color DISABLED_OR_HINT_TEXT_BLACK = Color.FromArgb(66, 0, 0, 0);
        private static readonly Brush DISABLED_OR_HINT_TEXT_BLACK_BRUSH = new SolidBrush(DISABLED_OR_HINT_TEXT_BLACK);
        private static readonly Color DIVIDERS_BLACK = Color.FromArgb(31, 0, 0, 0);
        private static readonly Brush DIVIDERS_BLACK_BRUSH = new SolidBrush(DIVIDERS_BLACK);

        private static readonly Color PRIMARY_TEXT_WHITE = Color.FromArgb(255, 255, 255, 255);
        private static readonly Brush PRIMARY_TEXT_WHITE_BRUSH = new SolidBrush(PRIMARY_TEXT_WHITE);
        public static Color SECONDARY_TEXT_WHITE = Color.FromArgb(179, 255, 255, 255);
        public static Brush SECONDARY_TEXT_WHITE_BRUSH = new SolidBrush(SECONDARY_TEXT_WHITE);
        private static readonly Color DISABLED_OR_HINT_TEXT_WHITE = Color.FromArgb(77, 255, 255, 255);
        private static readonly Brush DISABLED_OR_HINT_TEXT_WHITE_BRUSH = new SolidBrush(DISABLED_OR_HINT_TEXT_WHITE);
        private static readonly Color DIVIDERS_WHITE = Color.FromArgb(31, 255, 255, 255);
        private static readonly Brush DIVIDERS_WHITE_BRUSH = new SolidBrush(DIVIDERS_WHITE);

        // Checkbox colors
        private static readonly Color CHECKBOX_OFF_LIGHT = Color.FromArgb(138, 0, 0, 0);
        private static readonly Brush CHECKBOX_OFF_LIGHT_BRUSH = new SolidBrush(CHECKBOX_OFF_LIGHT);
        private static readonly Color CHECKBOX_OFF_DISABLED_LIGHT = Color.FromArgb(66, 0, 0, 0);
        private static readonly Brush CHECKBOX_OFF_DISABLED_LIGHT_BRUSH = new SolidBrush(CHECKBOX_OFF_DISABLED_LIGHT);

        private static readonly Color CHECKBOX_OFF_DARK = Color.FromArgb(179, 255, 255, 255);
        private static readonly Brush CHECKBOX_OFF_DARK_BRUSH = new SolidBrush(CHECKBOX_OFF_DARK);
        private static readonly Color CHECKBOX_OFF_DISABLED_DARK = Color.FromArgb(77, 255, 255, 255);
        private static readonly Brush CHECKBOX_OFF_DISABLED_DARK_BRUSH = new SolidBrush(CHECKBOX_OFF_DISABLED_DARK);

        //Raised button
        private static readonly Color RAISED_BUTTON_BACKGROUND = Color.FromArgb(255, 255, 255, 255);
        private static readonly Brush RAISED_BUTTON_BACKGROUND_BRUSH = new SolidBrush(RAISED_BUTTON_BACKGROUND);
        private static readonly Color RAISED_BUTTON_TEXT_LIGHT = PRIMARY_TEXT_WHITE;
        private static readonly Brush RAISED_BUTTON_TEXT_LIGHT_BRUSH = new SolidBrush(RAISED_BUTTON_TEXT_LIGHT);
        private static readonly Color RAISED_BUTTON_TEXT_DARK = PRIMARY_TEXT_BLACK;
        private static readonly Brush RAISED_BUTTON_TEXT_DARK_BRUSH = new SolidBrush(RAISED_BUTTON_TEXT_DARK);

        //Flat button
        private static readonly Color FLAT_BUTTON_BACKGROUND_HOVER_LIGHT = Color.FromArgb(20.PercentageToColorComponent(), 0x999999.ToColor());
        private static readonly Brush FLAT_BUTTON_BACKGROUND_HOVER_LIGHT_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_HOVER_LIGHT);
        private static readonly Color FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT = Color.FromArgb(40.PercentageToColorComponent(), 0x999999.ToColor());
        private static readonly Brush FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT);
        private static readonly Color FLAT_BUTTON_DISABLEDTEXT_LIGHT = Color.FromArgb(26.PercentageToColorComponent(), 0x000000.ToColor());
        private static readonly Brush FLAT_BUTTON_DISABLEDTEXT_LIGHT_BRUSH = new SolidBrush(FLAT_BUTTON_DISABLEDTEXT_LIGHT);

        private static readonly Color FLAT_BUTTON_BACKGROUND_HOVER_DARK = Color.FromArgb(15.PercentageToColorComponent(), 0xCCCCCC.ToColor());
        private static readonly Brush FLAT_BUTTON_BACKGROUND_HOVER_DARK_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_HOVER_DARK);
        private static readonly Color FLAT_BUTTON_BACKGROUND_PRESSED_DARK = Color.FromArgb(25.PercentageToColorComponent(), 0xCCCCCC.ToColor());
        private static readonly Brush FLAT_BUTTON_BACKGROUND_PRESSED_DARK_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_PRESSED_DARK);
        private static readonly Color FLAT_BUTTON_DISABLEDTEXT_DARK = Color.FromArgb(30.PercentageToColorComponent(), 0xFFFFFF.ToColor());
        private static readonly Brush FLAT_BUTTON_DISABLEDTEXT_DARK_BRUSH = new SolidBrush(FLAT_BUTTON_DISABLEDTEXT_DARK);

        //ContextMenuStrip
        private static readonly Color CMS_BACKGROUND_LIGHT_HOVER = Color.FromArgb(255, 238, 238, 238);
        private static readonly Brush CMS_BACKGROUND_HOVER_LIGHT_BRUSH = new SolidBrush(CMS_BACKGROUND_LIGHT_HOVER);

        private static readonly Color CMS_BACKGROUND_DARK_HOVER = Color.FromArgb(38, 204, 204, 204);
        private static readonly Brush CMS_BACKGROUND_HOVER_DARK_BRUSH = new SolidBrush(CMS_BACKGROUND_DARK_HOVER);

        //Application background
        private static readonly Color BACKGROUND_LIGHT = Color.FromArgb(255, 255, 255, 255);
        private static Brush BACKGROUND_LIGHT_BRUSH = new SolidBrush(BACKGROUND_LIGHT);

        private static readonly Color BACKGROUND_DARK = Color.FromArgb(255, 51, 51, 51);
        private static Brush BACKGROUND_DARK_BRUSH = new SolidBrush(BACKGROUND_DARK);

        //Application action bar
        public static readonly Color ACTION_BAR_TEXT = Color.FromArgb(255, 255, 255, 255);
        public static readonly Brush ACTION_BAR_TEXT_BRUSH = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
        public static readonly Color ACTION_BAR_TEXT_SECONDARY = Color.FromArgb(153, 255, 255, 255);
        public static readonly Brush ACTION_BAR_TEXT_SECONDARY_BRUSH = new SolidBrush(Color.FromArgb(153, 255, 255, 255));

        //Shadow color for all controls
        public static readonly Color SHADOW_COLOR = Color.FromArgb(255,0,0,0);
        public static readonly Color SOFT_SHADOW_COLOR = Color.FromArgb(20,0,0,0);

        public static bool SoftShadow { get; set; }

        //NOT IMPLEMENTED
        public static bool PrepareShadowOnStart { get; set; }

        public static Color GetPrimaryTextColor()
        {
            return (Theme == Themes.LIGHT ? PRIMARY_TEXT_BLACK : PRIMARY_TEXT_WHITE);
        }

        public static Brush GetPrimaryTextBrush()
        {
            return (Theme == Themes.LIGHT ? PRIMARY_TEXT_BLACK_BRUSH : PRIMARY_TEXT_WHITE_BRUSH);
        }

        public static Color GetSecondaryTextColor()
        {
            return (Theme == Themes.LIGHT ? SECONDARY_TEXT_BLACK : SECONDARY_TEXT_WHITE);
        }

        public static Brush GetSecondaryTextBrush()
        {
            return (Theme == Themes.LIGHT ? SECONDARY_TEXT_BLACK_BRUSH : SECONDARY_TEXT_WHITE_BRUSH);
        }

        public static Color GetDisabledOrHintColor()
        {
            return (Theme == Themes.LIGHT ? DISABLED_OR_HINT_TEXT_BLACK : DISABLED_OR_HINT_TEXT_WHITE);
        }

        public static Brush GetDisabledOrHintBrush()
        {
            return (Theme == Themes.LIGHT ? DISABLED_OR_HINT_TEXT_BLACK_BRUSH : DISABLED_OR_HINT_TEXT_WHITE_BRUSH);
        }

        public static Color GetDividersColor()
        {
            return (Theme == Themes.LIGHT ? DIVIDERS_BLACK : DIVIDERS_WHITE);
        }

        public static Brush GetDividersBrush()
        {
            return (Theme == Themes.LIGHT ? DIVIDERS_BLACK_BRUSH : DIVIDERS_WHITE_BRUSH);
        }

        public static Color GetCheckboxOffColor()
        {
            return (Theme == Themes.LIGHT ? CHECKBOX_OFF_LIGHT : CHECKBOX_OFF_DARK);
        }

        public static Brush GetCheckboxOffBrush()
        {
            return (Theme == Themes.LIGHT ? CHECKBOX_OFF_LIGHT_BRUSH : CHECKBOX_OFF_DARK_BRUSH);
        }

        public static Color GetCheckBoxOffDisabledColor()
        {
            return (Theme == Themes.LIGHT ? CHECKBOX_OFF_DISABLED_LIGHT : CHECKBOX_OFF_DISABLED_DARK);
        }

        public static Brush GetCheckBoxOffDisabledBrush()
        {
            return (Theme == Themes.LIGHT ? CHECKBOX_OFF_DISABLED_LIGHT_BRUSH : CHECKBOX_OFF_DISABLED_DARK_BRUSH);
        }

        public static Brush GetRaisedButtonBackgroundBrush()
        {
            return RAISED_BUTTON_BACKGROUND_BRUSH;
        }

        public static Brush GetRaisedButtonTextBrush(bool primary)
        {
            return (primary ? RAISED_BUTTON_TEXT_LIGHT_BRUSH : RAISED_BUTTON_TEXT_DARK_BRUSH);
        }

        public static Color GetFlatButtonHoverBackgroundColor()
        {
            return (Theme == Themes.LIGHT ? FLAT_BUTTON_BACKGROUND_HOVER_LIGHT : FLAT_BUTTON_BACKGROUND_HOVER_DARK);
        }

        public static Brush GetFlatButtonHoverBackgroundBrush()
        {
            return (Theme == Themes.LIGHT ? FLAT_BUTTON_BACKGROUND_HOVER_LIGHT_BRUSH : FLAT_BUTTON_BACKGROUND_HOVER_DARK_BRUSH);
        }

        public static Color GetFlatButtonPressedBackgroundColor()
        {
            return (Theme == Themes.LIGHT ? FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT : FLAT_BUTTON_BACKGROUND_PRESSED_DARK);
        }

        public static Brush GetFlatButtonPressedBackgroundBrush()
        {
            return (Theme == Themes.LIGHT ? FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT_BRUSH : FLAT_BUTTON_BACKGROUND_PRESSED_DARK_BRUSH);
        }

        public static Brush GetFlatButtonDisabledTextBrush()
        {
            return (Theme == Themes.LIGHT ? FLAT_BUTTON_DISABLEDTEXT_LIGHT_BRUSH : FLAT_BUTTON_DISABLEDTEXT_DARK_BRUSH);
        }

        public static Brush GetCmsSelectedItemBrush()
        {
            return (Theme == Themes.LIGHT ? CMS_BACKGROUND_HOVER_LIGHT_BRUSH : CMS_BACKGROUND_HOVER_DARK_BRUSH);
        }

        public static Color GetApplicationBackgroundColor()
        {
            return (Theme == Themes.LIGHT ? BACKGROUND_LIGHT : BACKGROUND_DARK);
        }

        public static Brush GetPanelBackgroundBrush(bool primary)
        {
            return (primary ? (Theme == Themes.LIGHT ? ColorScheme.LightPrimaryBrush : ColorScheme.DarkPrimaryBrush) : new SolidBrush(GetApplicationBackgroundColor()));
        }

        //Roboto font
        public static Font ROBOTO_MEDIUM_15;
        public static Font ROBOTO_MEDIUM_12;
        public static Font ROBOTO_REGULAR_11;
        public static Font ROBOTO_MEDIUM_11;
        public static Font ROBOTO_MEDIUM_10;
        public static Font ROBOTO_REGULAR_9;

        //Other constants
        public static int FORM_PADDING = 14;

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pvd, [In] ref uint pcFonts);

        static MaterialSkinManager()
        {
            ROBOTO_MEDIUM_15 = new Font(LoadFont(Resources.Roboto_Medium), 15f);
            ROBOTO_MEDIUM_12 = new Font(LoadFont(Resources.Roboto_Medium), 12f);
            ROBOTO_MEDIUM_10 = new Font(LoadFont(Resources.Roboto_Medium), 10f);
            ROBOTO_REGULAR_11 = new Font(LoadFont(Resources.Roboto_Regular), 11f);
            ROBOTO_MEDIUM_11 = new Font(LoadFont(Resources.Roboto_Medium), 11f);
            ROBOTO_REGULAR_9 = new Font(LoadFont(Resources.Roboto_Regular), 9f);
            Theme = Themes.LIGHT;
            ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        public static void AddFormToManage(MaterialForm materialForm)
        {
            formsToManage.Add(materialForm);
            UpdateBackgrounds();
        }

        public static void RemoveFormToManage(MaterialForm materialForm)
        {
            formsToManage.Remove(materialForm);
        }

        private static readonly PrivateFontCollection privateFontCollection = new PrivateFontCollection();

        private static FontFamily LoadFont(byte[] fontResource)
        {
            int dataLength = fontResource.Length;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontResource, 0, fontPtr, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(fontPtr, (uint)fontResource.Length, IntPtr.Zero, ref cFonts);
            privateFontCollection.AddMemoryFont(fontPtr, dataLength);

            return privateFontCollection.Families.Last();
        }

        private static void UpdateBackgrounds()
        {
            var newBackColor = GetApplicationBackgroundColor();
            foreach (var materialForm in formsToManage)
            {
                materialForm.BackColor = newBackColor;
                UpdateControl(materialForm, newBackColor);
            }
        }

        private static void UpdateToolStrip(ToolStrip toolStrip, Color newBackColor)
        {
            if (toolStrip == null) return;

            toolStrip.BackColor = newBackColor;
            foreach (ToolStripItem control in toolStrip.Items)
            {
                control.BackColor = newBackColor;
                if (control is MaterialToolStripMenuItem && (control as MaterialToolStripMenuItem).HasDropDownItems)
                {

                    //recursive call
                    UpdateToolStrip((control as MaterialToolStripMenuItem).DropDown, newBackColor);
                }
            }
        }

        private static void UpdateControl(Control controlToUpdate, Color newBackColor)
        {
            if (controlToUpdate == null) return;

            if (controlToUpdate.ContextMenuStrip != null)
            {
                UpdateToolStrip(controlToUpdate.ContextMenuStrip, newBackColor);
            }
            var tabControl = controlToUpdate as MaterialTabControl;
            if (tabControl != null)
            {
                foreach (TabPage tabPage in tabControl.TabPages)
                {
                    tabPage.BackColor = newBackColor;
                }
            }

            if (controlToUpdate is MaterialDivider)
            {
                controlToUpdate.BackColor = GetDividersColor();
            }

            if (controlToUpdate is MaterialListView)
            {
                controlToUpdate.BackColor = newBackColor;
            }

            if (controlToUpdate is MaterialSingleLineTextField)
            {
                controlToUpdate.BackColor = newBackColor;
            }

            if (controlToUpdate is MaterialLabel)
            {
                controlToUpdate.BackColor = newBackColor;
            }

            //recursive call
            foreach (Control control in controlToUpdate.Controls)
            {
                UpdateControl(control, newBackColor);
            }

            controlToUpdate.Invalidate();
        }
    }
}
