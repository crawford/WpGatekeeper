namespace WpGatekeeper.Models
{
    public class Door
    {
        public enum LockStatus
        {
            UNLOCKED,
            LOCKED,
            UNKNOWN
        };
        public string Name { get; set; }
        public LockStatus Status { get; set; }
        public int Id { get; set; }
    }
}
