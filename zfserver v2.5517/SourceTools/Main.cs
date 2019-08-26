using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace SourceTools
{
    public partial class Main : MaterialForm
    {
        private Manager MyManager;

        public Main()
        {
            InitializeComponent();
            // MaterialSkin
            MaterialSkinManager.AddFormToManage(this);
            MaterialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            // Initialize MyManager
            MyManager = new Manager();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MyManager.ConnectToServer();
        }

        private void BtnLoadNPCs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Loaded " + MyManager.GetNPCS().Count + " NPCs");
        }
    }
}
