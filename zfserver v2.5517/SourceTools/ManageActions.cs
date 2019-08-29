using DB;
using DB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SourceTools
{
    public partial class ManageActions : MetroFramework.Forms.MetroForm
    {
        public ManageActions()
        {
            InitializeComponent();
        }

        private void ManageActions_Load(object sender, EventArgs e)
        {
            Text = "Manage actions of NPC: " + Manager.selectedNPC.Name;
            txtMainActionParam.CustomButton.Click += MainActionSave_Click;
            Manager.selectedAction = Manager.GetActions().Where(x => x.Identity == Manager.selectedNPC.Task0 && x.IdNext != 0).FirstOrDefault();
            if (Manager.selectedAction != null)
            {
                txtMainActionParam.Text = "Main action ID: " + Manager.selectedAction.Identity;
                LoadActions();
            } else
            {
                txtMainActionParam.Text = "This NPC not have actions";
            }
        }

        private void MainActionSave_Click(object sender, EventArgs e)
        {
            Manager.actionRepository.SaveOrUpdate(Manager.selectedAction, SessionFactory.GameDatabase.OpenSession());
            foreach(DbGameAction act in Manager.actionChildEntities)
            {
                Manager.actionRepository.SaveOrUpdate(act, SessionFactory.GameDatabase.OpenSession());
            }
        }

        private void LoadActions()
        {

            #region Load All Action Childs
            Manager.actionChildEntities = new BindingList<DbGameAction>
            {
                Manager.selectedAction
            };
            if (Manager.selectedAction.IdNextfail != 0)
            {
                GetChildActions(Manager.selectedAction, true);
            }
            GetChildActions(Manager.selectedAction);
            gridViewActions.DataSource = Manager.actionChildEntities;
            #endregion
        }

        public void GetChildActions(DbGameAction parentAction, bool FailChilds = false)
        {
            if (parentAction != null)
            {
                uint actionID = FailChilds ? parentAction.IdNextfail : parentAction.IdNext;
                DbGameAction action = Manager.GetActions().Where(x => x.Identity == actionID).FirstOrDefault();
                if (action != null && action.Identity != 0)
                {
                    if (Manager.actionChildEntities.Where(x => x.Identity == action.Identity).Count() <= 0)
                    {
                        Manager.actionChildEntities.Add(action);
                        if (action.Type == 102)
                        {
                            string[] paramParameters = action.Param.Split(' ');
                            uint.TryParse(paramParameters[paramParameters.Length - 1], out uint ParamActionID);
                            if (ParamActionID != 0)
                            {
                                DbGameAction actionParam = Manager.GetActions().Where(x => x.Identity == ParamActionID).FirstOrDefault();
                                Manager.actionChildEntities.Add(actionParam);
                                GetChildActions(actionParam);
                            }
                        }
                        GetChildActions(action);
                        if (action.IdNextfail != 0)
                        {
                            GetChildActions(action, true);
                        }
                    }
                }
            }
        }
    }
}
