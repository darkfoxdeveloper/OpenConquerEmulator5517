using DB;

namespace SourceTools
{
    public class Manager
    {
        public SessionFactory currentSession;
        public DB.Repositories.NpcRepository npcRepository;

        public void ConnectToServer()
        {
            currentSession = new SessionFactory("Shell.ini", "Login.cfg", true);
            npcRepository = new DB.Repositories.NpcRepository();
        }
    }
}
