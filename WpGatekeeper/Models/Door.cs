using System;
using System.Runtime.Serialization;

namespace WpGatekeeper.Models
{
    [DataContract]
    public class Door
    {
        public enum LockStatus
        {
            UNKNOWN,
            UNLOCKED,
            LOCKED
        };

        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name = "state")]
        public string LockStatusString
        {
            get
            {
                return Status.ToString();
            }
            set
            {
                switch (value.ToLower())
                {
                    case "locked":
                        Status = LockStatus.LOCKED;
                        break;
                    case "unlocked":
                        Status = LockStatus.UNLOCKED;
                        break;
                    case "unknown":
                        Status = LockStatus.UNKNOWN;
                        break;
                    default:
                        throw (new ArgumentException("Invalid lock state"));
                }
            }
        }
        public LockStatus Status { get; set; }

        [DataMember(Name="id")]
        public int Id { get; set; }
    }
}
