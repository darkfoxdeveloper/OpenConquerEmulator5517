using MetroFramework.Forms;
using System;
using System.Linq;
using System.Collections.Generic;
using MetroFramework.Controls;
using System.ComponentModel;
using ServerCore.Common.Enums;

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
            Manager.GetNPCs().Where(x => x.Id == ((DB.Entities.DbNpc)selected.SelectedItem).Id).ToList();
            DB.Entities.DbGameAction action = Manager.GetActions().Where(x => x.Identity == ((DB.Entities.DbNpc)selected.SelectedItem).Task0).FirstOrDefault();
            DB.Entities.DbGameAction Act1, Act2, Act3, Act4, Act5, Act6;
            if (action != null)
            {
                switch ((TaskActionType)action.Type)
                {
                    case TaskActionType.ACTION_MENUTEXT:
                        {
                            lblAction.Text = action.Param;
                            if (action.IdNext > 0)
                            {
                                Act1 = Manager.GetActions().Where(x => x.Identity == action.IdNext).FirstOrDefault();
                                lblAction1.Text = Act1.Param;
                                if (Act1 != null)
                                {
                                    Act2 = Manager.GetActions().Where(x => x.Identity == Act1.IdNext).FirstOrDefault();
                                    lblAction2.Text = Act2.Param;
                                    if (Act2 != null)
                                    {
                                        Act3 = Manager.GetActions().Where(x => x.Identity == Act2.IdNext).FirstOrDefault();
                                        lblAction3.Text = Act3.Param;
                                    }
                                }
                                // TODO Improve this method for load all actions with a for or while
                            }
                            break;
                        }
                    case TaskActionType.ACTION_MENULINK: break;
                    case TaskActionType.ACTION_MENUEDIT: break;
                    case TaskActionType.ACTION_MENUPIC: break;
                    case TaskActionType.ACTION_MENUCREATE: break;
                    case TaskActionType.ACTION_RAND: break;
                    case TaskActionType.ACTION_RANDACTION: break;
                    case TaskActionType.ACTION_CHKTIME: break;
                    case TaskActionType.ACTION_BROCASTMSG: break;
                    case TaskActionType.ACTION_EXECUTEQUERY: break;
                }
            }
        }
    }
}
