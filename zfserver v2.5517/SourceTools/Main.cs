using MetroFramework.Forms;
using System;
using System.Linq;
using System.Collections.Generic;
using MetroFramework.Controls;
using System.ComponentModel;
using ServerCore.Common.Enums;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Drawing;

namespace SourceTools
{
    public partial class Main : MetroForm
    {
        private const string SEARCH_HELP = "Search...";
        private const uint SEARCH_TIMEOUT_SECONDS = 0;
        private DateTime lastSearch = DateTime.Now;
        private List<MetroTextBox> inputsItem = new List<MetroTextBox>();
        private DB.Entities.DbItemtype selectedItemtype;

        public Main()
        {
            InitializeComponent();
            Manager.ConnectToServer();
            txtSearch.Text = SEARCH_HELP;
            RefreshNPCList();
            RefreshItemsList();
        }

        private void RefreshNPCList(IList<DB.Entities.DbNpc> sourceList = null)
        {
            if (sourceList == null)
            {
                sourceList = Manager.GetNPCs().Where(x => x.Type == 2).ToList();
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

        private void RefreshItemsList(IList<DB.Entities.DbItemtype> sourceList = null)
        {
            if (sourceList == null)
            {
                sourceList = Manager.GetItemtypes().ToList();
            }
            BindingList<DB.Entities.DbItemtype> objects = new BindingList<DB.Entities.DbItemtype>();
            foreach (DB.Entities.DbItemtype item in sourceList)
            {
                objects.Add(item);
            }
            listItems.ValueMember = null;
            listItems.DisplayMember = "Name";
            listItems.DataSource = objects;
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
                IList<DB.Entities.DbNpc> n = Manager.GetNPCs().Where(x => x.Type == 2 && (x.Name.Contains(txt.Text) || x.Id.Equals(txt.Text))).ToList();
                RefreshNPCList(n);
            }
        }

        private void ListNPCs_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMainDialogText.Text = "";
            MetroComboBox selected = ((MetroComboBox)sender);
            Manager.GetNPCs().Where(x => x.Id == ((DB.Entities.DbNpc)selected.SelectedItem).Id).ToList();
            DB.Entities.DbGameAction action = Manager.GetActions().Where(x => x.Identity == ((DB.Entities.DbNpc)selected.SelectedItem).Task0).FirstOrDefault();
            List<DB.Entities.DbGameAction> CurrentNPCActions = new List<DB.Entities.DbGameAction>();
            if (action != null)
            {
                uint nAct = 0;
                switch ((TaskActionType)action.Type)
                {
                    case TaskActionType.ACTION_MENUTEXT:
                        {
                            lblMainDialogText.Text = action.Param;
                            lblMainDialogText.Tag = action;
                            var previousAct = action;
                            while (action.IdNext != 0 && nAct <= 5)
                            {
                                DB.Entities.DbGameAction actionX = Manager.GetActions().Where(x => x.Identity == previousAct.IdNext).FirstOrDefault();
                                previousAct = actionX;
                                if (actionX != null && actionX.Identity != 0)
                                {
                                    CurrentNPCActions.Add(actionX);
                                    if ((TaskActionType)actionX.Type != TaskActionType.ACTION_MENULINK) break;
                                    switch (nAct)
                                    {
                                        case 0:
                                            {
                                                lblAction1.Text = actionX.Param;
                                                lblAction1.Tag = actionX;
                                                break;
                                            }
                                        case 1:
                                            {
                                                lblAction2.Text = actionX.Param;
                                                lblAction2.Tag = actionX;
                                                break;
                                            }
                                        case 2:
                                            {
                                                lblAction3.Text = actionX.Param;
                                                lblAction3.Tag = actionX;
                                                break;
                                            }
                                        case 3:
                                            {
                                                lblAction4.Text = actionX.Param;
                                                lblAction4.Tag = actionX;
                                                break;
                                            }
                                        case 4:
                                            {
                                                lblAction5.Text = actionX.Param;
                                                lblAction5.Tag = actionX;
                                                break;
                                            }
                                        case 5:
                                            {
                                                lblAction6.Text = actionX.Param;
                                                lblAction6.Tag = actionX;
                                                break;
                                            }
                                    }
                                }
                                nAct++;
                            }
                            break;
                        }
                    //case TaskActionType.ACTION_MENULINK: break;
                    //case TaskActionType.ACTION_MENUEDIT: break;
                    //case TaskActionType.ACTION_MENUPIC: break;
                    //case TaskActionType.ACTION_MENUCREATE: break;
                    //case TaskActionType.ACTION_RAND: break;
                    //case TaskActionType.ACTION_RANDACTION: break;
                    //case TaskActionType.ACTION_CHKTIME: break;
                    //case TaskActionType.ACTION_BROCASTMSG: break;
                    //case TaskActionType.ACTION_EXECUTEQUERY: break;
                    default:
                        {
                            lblMainDialogText.Text = action.Param;
                            lblMainDialogText.Tag = action;
                            break;
                        }
                }
                lblAction1.Visible = nAct > 0;
                lblAction2.Visible = nAct > 1;
                lblAction3.Visible = nAct > 2;
                lblAction4.Visible = nAct > 3;
                lblAction5.Visible = nAct > 4;
                lblAction6.Visible = nAct > 5;
            }
        }

        private void LblActionLink_Click(object sender, EventArgs e)
        {
            Label label = ((Label)sender);
            if (label.Tag != null)
            {
                uint ActionIDX = Convert.ToUInt32(Regex.Match(((DB.Entities.DbGameAction)label.Tag).Param, @"\d+$").Value);
                DB.Entities.DbGameAction actionX = Manager.GetActions().Where(x => x.Identity == ActionIDX).FirstOrDefault();
                if (actionX != null)
                {
                    lblMainDialogText.Text = actionX.Param;
                    lblMainDialogText.Tag = actionX;
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            var propierties = typeof(DB.Entities.DbItemtype).GetProperties();
            var n = 0;
            foreach (var prop in propierties)
            {
                var inp = new MetroTextBox()
                {
                    Name = prop.Name,
                    Location = new Point(DynamicInputs.Location.X, DynamicInputs.Location.Y),
                    Width = 145,
                    Tag = "",
                    Padding = new Padding(15)
                };
                inp.TextChanged += Inp_TextChanged;
                inputsItem.Add(inp);
                panelAttributes.Controls.Add(inp);
                n++;
            }
        }

        private void Inp_TextChanged(object sender, EventArgs e)
        {
            MetroTextBox txt = (MetroTextBox)sender;
            Manager.SetValueOf(selectedItemtype, txt.Name, txt.Text);
        }

        private void ListItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItemtype = (DB.Entities.DbItemtype)listItems.SelectedItem;
            foreach (MetroTextBox input in inputsItem)
            {
                input.Text = selectedItemtype.GetType().GetProperty(input.Name).GetValue(selectedItemtype).ToString();
            }
        }

        private void TxtSearchItems_TextChanged(object sender, EventArgs e)
        {
            MetroTextBox txt = (MetroTextBox)sender;
            if (txt.Text.Equals(SEARCH_HELP) || txt.Text.Length == 0)
            {
                RefreshItemsList();
            }
            else if (txt.Text.Length > 3 && DateTime.Now > lastSearch.AddSeconds(SEARCH_TIMEOUT_SECONDS))
            {
                lastSearch = DateTime.Now;
                IList<DB.Entities.DbItemtype> n = Manager.GetItemtypes().Where(x => x.Name.Contains(txt.Text) || x.Ident.Equals(txt.Text)).ToList();
                RefreshItemsList(n);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Manager.itemtypeRepository.SaveOrUpdate(selectedItemtype);
        }
    }
}
