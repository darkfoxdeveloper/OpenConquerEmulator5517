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
            Manager.actionChildEntities = GetChildActions(Manager.selectedAction, true);
            gridViewActions.DataSource = Manager.actionChildEntities;
            gridViewActions.Columns[0].ReadOnly = true;
            #endregion
        }

        public BindingList<DbGameAction> GetChildActions(DbGameAction parentAction, bool addParent = false)
        {
            BindingList<DbGameAction> listChildActions = new BindingList<DbGameAction>();
            if (addParent)
            {
                listChildActions.Add(parentAction);
            }
            DbGameAction actionX = null;
            uint n = 0;
            do
            {
                uint actionId = n == 0 ? parentAction.IdNext : actionX.IdNext;
                DbGameAction whereAction = n == 0 ? parentAction : actionX;
                actionX = Manager.GetActions().Where(x => (x.Identity == whereAction.IdNext) && (x.IdNext != 0)).FirstOrDefault();
                if (actionX != null)
                {
                    listChildActions.Add(actionX);
                }
                if (whereAction.IdNextfail > 0)
                {
                    DbGameAction actionX2 = Manager.GetActions().Where(x => (x.Identity == whereAction.IdNextfail) && (x.Identity != 0)).FirstOrDefault();
                    if (actionX2 != null) listChildActions.Add(actionX2);
                    DbGameAction actionX3 = Manager.GetActions().Where(x => (x.Identity == actionX2.IdNextfail) && (x.Identity != 0)).FirstOrDefault();
                    if (actionX3 != null) listChildActions.Add(actionX3);
                }
                n++;
            } while (actionX != null && actionX.Identity != 0);
            return listChildActions;
        }
    }
}
