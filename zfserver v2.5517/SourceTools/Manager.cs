using DB;
using System.Collections.Generic;

namespace SourceTools
{
    public static class Manager
    {
        private static SessionFactory currentSession;
        public static DB.Repositories.NpcRepository npcRepository;
        public static DB.Repositories.GameActionRepo actionRepository;
        public static DB.Repositories.ItemtypeRepository itemtypeRepository;
        public static IList<DB.Entities.DbNpc> npcEntities;
        public static IList<DB.Entities.DbGameAction> actionEntities;
        public static IList<DB.Entities.DbItemtype> itemtypeEntities;

        public static void ConnectToServer()
        {
            currentSession = new SessionFactory("Shell.ini", "Login.cfg", true);
            LoadRepositories();
        }

        public static void LoadRepositories()
        {
            npcRepository = new DB.Repositories.NpcRepository();
            actionRepository = new DB.Repositories.GameActionRepo();
            itemtypeRepository = new DB.Repositories.ItemtypeRepository();
        }

        public static IList<DB.Entities.DbNpc> GetNPCs(bool forceFetch = false)
        {
            if (npcEntities == null || forceFetch) npcEntities = npcRepository.FetchAll();
            return npcEntities;
        }

        public static IList<DB.Entities.DbGameAction> GetActions(bool forceFetch = false)
        {
            if (actionEntities == null || forceFetch) actionEntities = actionRepository.FetchAll();
            return actionEntities;
        }

        public static IList<DB.Entities.DbItemtype> GetItemtypes(bool forceFetch = false)
        {
            if (itemtypeEntities == null || forceFetch) itemtypeEntities = itemtypeRepository.FetchAll();
            return itemtypeEntities;
        }
    }
}
