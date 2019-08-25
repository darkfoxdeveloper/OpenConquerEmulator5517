using MaterialSkin;
using MaterialSkin.Controls;
using System;

namespace SourceTools
{
    public partial class Main : MaterialForm
    {
        public Main()
        {
            InitializeComponent();
            // MaterialSkin
            MaterialSkinManager.AddFormToManage(this);
            MaterialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }
    }
}
