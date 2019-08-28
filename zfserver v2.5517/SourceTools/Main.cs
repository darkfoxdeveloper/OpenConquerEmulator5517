using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SourceTools
{
    public partial class Main : MetroForm
    {
        private const string SEARCH_HELP = "Search...";
        private const uint SEARCH_TIMEOUT_SECONDS = 0;
        private DateTime lastSearch = DateTime.Now;
        //private List<MetroTextBox> inputsItem = new List<MetroTextBox>();
        private DB.Entities.DbItemtype selectedItemtype;
        private DB.Entities.DbNpc selectedNPC;
        private string PreviousTitle;

        public Main()
        {
            InitializeComponent();
            Manager.ConnectToServer();
            Manager.MainForm = this;
            txtSearch.Text = SEARCH_HELP;
            txtSearchItems.Text = SEARCH_HELP;
            RefreshNPCList();
            RefreshItemsList();
            PreviousTitle = Text;
        }

        public void SavedWarning(bool active = false)
        {
            if (active)
            {
                Text = PreviousTitle + "*";
            } else
            {
                Text = PreviousTitle;
            }
        }

        private void RefreshNPCList(IList<DB.Entities.DbNpc> sourceList = null)
        {
            if (sourceList == null)
            {
                sourceList = Manager.GetNPCs().ToList();
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
            MetroTextBox mtb = (MetroTextBox)sender;
            if (mtb.Text.Length <= 0) mtb.Text = SEARCH_HELP;
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            MetroTextBox mtb = (MetroTextBox)sender;
            if (mtb.Text.Equals(SEARCH_HELP)) mtb.Clear();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            MetroTextBox txt = (MetroTextBox)sender;
            if (txt.Text.Equals(SEARCH_HELP) || txt.Text.Length == 0) return;
            if (txt.Text.Length > 3 && DateTime.Now > lastSearch.AddSeconds(SEARCH_TIMEOUT_SECONDS))
            {
                lastSearch = DateTime.Now;
                IList<DB.Entities.DbNpc> n = Manager.GetNPCs().Where(x => x.Type == 2 && (x.Name.Contains(txt.Text) || x.Id.Equals(txt.Text))).ToList();
                RefreshNPCList(n);
            }
        }

        private void ListNPCs_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetroComboBox selected = ((MetroComboBox)sender);

            selectedNPC = (DB.Entities.DbNpc)listNPCs.SelectedItem;
            foreach (MetroTextBox input in panelActions.Controls.OfType<MetroTextBox>())
            {
                if (input.Enabled && input.Visible)
                {
                    input.Text = selectedNPC.GetType().GetProperty(input.Name).GetValue(selectedNPC).ToString();
                }
            }

            //Manager.GetNPCs().Where(x => x.Id == ((DB.Entities.DbNpc)selected.SelectedItem).Id).ToList();
            //DB.Entities.DbGameAction action = Manager.GetActions().Where(x => x.Identity == ((DB.Entities.DbNpc)selected.SelectedItem).Task0).FirstOrDefault();
            //List<DB.Entities.DbGameAction> CurrentNPCActions = new List<DB.Entities.DbGameAction>();
            //if (action != null)
            //{
            //    uint nAct = 0;
            //    switch ((TaskActionType)action.Type)
            //    {
            //        case TaskActionType.ACTION_MENUTEXT:
            //            {
            //                lblMainDialogText.Text = action.Param;
            //                lblMainDialogText.Tag = action;
            //                var previousAct = action;
            //                while (action.IdNext != 0 && nAct <= 5)
            //                {
            //                    DB.Entities.DbGameAction actionX = Manager.GetActions().Where(x => x.Identity == previousAct.IdNext).FirstOrDefault();
            //                    previousAct = actionX;
            //                    if (actionX != null && actionX.Identity != 0)
            //                    {
            //                        CurrentNPCActions.Add(actionX);
            //                        if ((TaskActionType)actionX.Type != TaskActionType.ACTION_MENULINK) break;
            //                        switch (nAct)
            //                        {
            //                            case 0:
            //                                {
            //                                    lblAction1.Text = actionX.Param;
            //                                    lblAction1.Tag = actionX;
            //                                    break;
            //                                }
            //                            case 1:
            //                                {
            //                                    lblAction2.Text = actionX.Param;
            //                                    lblAction2.Tag = actionX;
            //                                    break;
            //                                }
            //                            case 2:
            //                                {
            //                                    lblAction3.Text = actionX.Param;
            //                                    lblAction3.Tag = actionX;
            //                                    break;
            //                                }
            //                            case 3:
            //                                {
            //                                    lblAction4.Text = actionX.Param;
            //                                    lblAction4.Tag = actionX;
            //                                    break;
            //                                }
            //                            case 4:
            //                                {
            //                                    lblAction5.Text = actionX.Param;
            //                                    lblAction5.Tag = actionX;
            //                                    break;
            //                                }
            //                            case 5:
            //                                {
            //                                    lblAction6.Text = actionX.Param;
            //                                    lblAction6.Tag = actionX;
            //                                    break;
            //                                }
            //                        }
            //                    }
            //                    nAct++;
            //                }
            //                break;
            //            }
            //        //case TaskActionType.ACTION_MENULINK: break;
            //        //case TaskActionType.ACTION_MENUEDIT: break;
            //        //case TaskActionType.ACTION_MENUPIC: break;
            //        //case TaskActionType.ACTION_MENUCREATE: break;
            //        //case TaskActionType.ACTION_RAND: break;
            //        //case TaskActionType.ACTION_RANDACTION: break;
            //        //case TaskActionType.ACTION_CHKTIME: break;
            //        //case TaskActionType.ACTION_BROCASTMSG: break;
            //        //case TaskActionType.ACTION_EXECUTEQUERY: break;
            //        default:
            //            {
            //                lblMainDialogText.Text = action.Param;
            //                lblMainDialogText.Tag = action;
            //                break;
            //            }
            //    }
            //    lblAction1.Visible = nAct > 0;
            //    lblAction2.Visible = nAct > 1;
            //    lblAction3.Visible = nAct > 2;
            //    lblAction4.Visible = nAct > 3;
            //    lblAction5.Visible = nAct > 4;
            //    lblAction6.Visible = nAct > 5;
            //}
        }

        private void Main_Load(object sender, EventArgs e)
        {
            #region Load All Itemtype Inputs
            var propierties = typeof(DB.Entities.DbItemtype).GetProperties();
            var n = 0;
            foreach (var prop in propierties)
            {
                var inp = new MetroTextBox()
                {
                    Name = prop.Name,
                    Location = new Point(DynamicInputs.Location.X, DynamicInputs.Location.Y),
                    Width = 145,
                    Padding = new Padding(15)
                };
                inp.TextChanged += Inp_TextChanged;
                inp.GotFocus += InputItemtypeItem_GotFocus;
                inp.LostFocus += InputItemtypeItem_LostFocus;
                panelAttributes.Controls.Add(inp);
                n++;
            }
            #endregion
            #region Load All NPC Inputs
            var propierties2 = typeof(DB.Entities.DbNpc).GetProperties();
            var n2 = 0;
            foreach (var prop in propierties2)
            {
                var inp = new MetroTextBox()
                {
                    Name = prop.Name,
                    Location = new Point(dynamicInputsNPC.Location.X, dynamicInputsNPC.Location.Y),
                    Width = 145,
                    Padding = new Padding(15)
                };
                inp.TextChanged += InpNPC_TextChanged;
                inp.GotFocus += InputNPC_GotFocus;
                inp.LostFocus += InputNPC_LostFocus;
                panelActions.Controls.Add(inp);
                n2++;
            }
            #endregion
            noFilterNPCSearch.Checked = true;
            noFilterItemSearch.Checked = true;
            txtSearch.Enabled = false;
            txtSearchItems.Enabled = false;
            noFilterNPCSearch.CheckedChanged += NoFilterNPCSearch_CheckedChanged;
            noFilterItemSearch.CheckedChanged += NoFilterItemSearch_CheckedChanged;
        }

        #region Input Events
        private void NoFilterNPCSearch_CheckedChanged(object sender, EventArgs e)
        {
            MetroCheckBox control = (MetroCheckBox)sender;
            txtSearch.Enabled = !control.Checked;
            if (!txtSearchItems.Enabled)
            {
                RefreshNPCList();
            }
        }

        private void NoFilterItemSearch_CheckedChanged(object sender, EventArgs e)
        {
            MetroCheckBox control = (MetroCheckBox)sender;
            txtSearchItems.Enabled = !control.Checked;
            if (!txtSearchItems.Enabled)
            {
                RefreshItemsList();
            }
        }

        private void InputNPC_GotFocus(object sender, EventArgs e)
        {
            MetroTextBox mtb = (MetroTextBox)sender;
            lblHelperNPCs.Text = "The " + mtb.Name + " attribute";
        }

        private void InputNPC_LostFocus(object sender, EventArgs e)
        {
            lblHelperNPCs.Text = "Change a NPC. Select any NPC";
        }

        private void InputItemtypeItem_GotFocus(object sender, EventArgs e)
        {
            MetroTextBox mtb = (MetroTextBox)sender;
            lblHelperItemtypeItems.Text = "The " + mtb.Name + " attribute";
        }

        private void InputItemtypeItem_LostFocus(object sender, EventArgs e)
        {
            lblHelperItemtypeItems.Text = "Change a Item attributes. Select any Item";
        }

        private void Inp_TextChanged(object sender, EventArgs e)
        {
            MetroTextBox txt = (MetroTextBox)sender;
            Manager.SetValueOf(selectedItemtype, txt.Name, txt.Text);
        }

        private void InpNPC_TextChanged(object sender, EventArgs e)
        {
            MetroTextBox txt = (MetroTextBox)sender;
            Manager.SetValueOf(selectedNPC, txt.Name, txt.Text);
        }
        #endregion

        private void ListItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItemtype = (DB.Entities.DbItemtype)listItems.SelectedItem;
            foreach (MetroTextBox input in panelAttributes.Controls.OfType<MetroTextBox>())
            {
                if (input.Enabled && input.Visible)
                {
                    input.Text = selectedItemtype.GetType().GetProperty(input.Name).GetValue(selectedItemtype).ToString();
                }
            }
        }

        private void TxtSearchItems_TextChanged(object sender, EventArgs e)
        {
            MetroTextBox txt = (MetroTextBox)sender;
            if (txt.Text.Equals(SEARCH_HELP) || txt.Text.Length == 0) return;
            if (txt.Text.Length > 3 && DateTime.Now > lastSearch.AddSeconds(SEARCH_TIMEOUT_SECONDS))
            {
                lastSearch = DateTime.Now;
                IList<DB.Entities.DbItemtype> n = Manager.GetItemtypes().Where(x => x.Name.Contains(txt.Text) || x.Ident.Equals(txt.Text)).ToList();
                RefreshItemsList(n);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Manager.itemtypeRepository.SaveOrUpdate(selectedItemtype);
            SavedWarning(false);
        }

        private void BtnSaveMainAction_Click(object sender, EventArgs e)
        {
            Manager.npcRepository.SaveOrUpdate(selectedNPC);
            SavedWarning(false);
        }
    }
}
