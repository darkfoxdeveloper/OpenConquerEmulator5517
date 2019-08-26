using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Linq;
using SourceTools.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SourceTools
{
    public class Manager
    {
        public ISession currentSession;
        private List<DbNpc> npcs;

        public void ConnectToServer()
        {
            currentSession = FluentNHibernateHelper.OpenSession();
        }

        public List<DbNpc> GetNPCS()
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                npcs = session.Query<DbNpc>().ToList();
            }
            return npcs;
        }
    }

    public static class FluentNHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure().Database(MySQLConfiguration.Standard.ConnectionString(c => c.FromConnectionStringWithKey("DBConnectionString")))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<DbNpc>())
                    .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}
