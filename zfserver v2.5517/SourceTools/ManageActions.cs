using DB;
using DB.Entities;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
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
            txtMainActionParam.CustomButton.Click += MainActionSave_Click;
            Manager.selectedAction = Manager.GetActions().Where(x => x.Identity == Manager.selectedNPC.Task0).FirstOrDefault();
            txtMainActionParam.Text = "NPC Selected:" + Manager.selectedAction.Identity;
            txtMainActionParam.Enabled = Manager.selectedAction.Identity > 0;
            LoadActions();
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
            dataGridView1.DataSource = Manager.actionChildEntities;
            #endregion
        }

        public List<DbGameAction> GetChildActions(DbGameAction parentAction, bool addParent = false)
        {
            List<DbGameAction> listChildActions = new List<DbGameAction>();
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
                    actionX = Manager.GetActions().Where(x => (x.Identity == whereAction.IdNextfail) && (x.Identity != 0)).FirstOrDefault();
                    if (actionX != null) listChildActions.Add(actionX);
                }
                n++;
            } while (actionX != null && actionX.Identity != 0);
            return listChildActions;
        }
    }
}
