using DB;
using System;
using System.Collections.Generic;
using System.Reflection;

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

        public static void SetValueOf(object obj, string prop, string value)
        {
            PropertyInfo objPrInfo = obj.GetType().GetProperty(prop);
            if (objPrInfo.PropertyType == typeof(uint))
            {
                obj.GetType().GetProperty(prop).SetValue(obj, uint.Parse(value));
            } else if (objPrInfo.PropertyType == typeof(UInt16)) {
                obj.GetType().GetProperty(prop).SetValue(obj, UInt16.Parse(value));
            }
            else if (objPrInfo.PropertyType == typeof(int))
            {
                obj.GetType().GetProperty(prop).SetValue(obj, int.Parse(value));
            }
            else if (objPrInfo.PropertyType == typeof(Int16))
            {
                obj.GetType().GetProperty(prop).SetValue(obj, Int16.Parse(value));
            }
            else if (objPrInfo.PropertyType == typeof(byte))
            {
                obj.GetType().GetProperty(prop).SetValue(obj, byte.Parse(value));
            }
            else
            {
                obj.GetType().GetProperty(prop).SetValue(obj, value);
            }
        }
    }
}
