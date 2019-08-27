using MetroFramework.Forms;
using System;
using System.Linq;
using System.Collections.Generic;
using MetroFramework.Controls;
using System.ComponentModel;

namespace SourceTools
{
    public partial class Main : MetroForm
    {
        private const string SEARCH_HELP = "Search...";
        private const uint SEARCH_TIMEOUT_SECONDS = 0;
        private DateTime lastSearch = DateTime.Now;

        public Main()
        {
            InitializeComponent();
            Manager.ConnectToServer();
            txtSearch.Text = SEARCH_HELP;
            RefreshNPCList();
        }

        private void RefreshNPCList(IList<DB.Entities.DbNpc> sourceList = null)
        {
            //listNPCs.Items.Clear();
            if (sourceList == null)
            {
                sourceList = Manager.GetNPCs();
            }
            BindingList<DB.Entities.DbNpc> objects = new BindingList<DB.Entities.DbNpc>();
            foreach (DB.Entities.DbNpc npc in sourceList)
            {
                objects.Add(npc);
            }
            listNPCs.ValueMember = null;
            listNPCs.DisplayMember = "Name";
            listNPCs.DataSource = objects;
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length <= 0) txtSearch.Text = SEARCH_HELP;
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Equals(SEARCH_HELP)) txtSearch.Clear();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            MetroTextBox txt = (MetroTextBox)sender;
            if (txt.Text.Equals(SEARCH_HELP) || txt.Text.Length == 0)
            {
                RefreshNPCList();
            } else if (txt.Text.Length > 3 && DateTime.Now > lastSearch.AddSeconds(SEARCH_TIMEOUT_SECONDS))
            {
                lastSearch = DateTime.Now;
                IList<DB.Entities.DbNpc> n = Manager.GetNPCs().Where(x => x.Name.Contains(txt.Text) || x.Id.Equals(txt.Text)).ToList();
                RefreshNPCList(n);
            }
        }

        private void ListNPCs_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMainDialogText.Text = "";
            MetroComboBox selected = ((MetroComboBox)sender);
            //System.Windows.Forms.MessageBox.Show(((DB.Entities.DbNpc)selected.SelectedItem).Id + "");
            //Manager.GetNPCs().Where(x => x.Id.Equals("").ToList();
        }
    }
}
