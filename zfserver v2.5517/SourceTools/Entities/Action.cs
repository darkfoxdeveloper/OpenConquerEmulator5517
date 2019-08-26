namespace SourceTools.Entities
{
    public class Action
    {
        public uint Id { get; set; }
        public uint IdNext { get; set; }
        public uint IdNextFail { get; set; }
        public uint Type { get; set; }
        public uint Data { get; set; }
        public string Param { get; set; }
    }
}
