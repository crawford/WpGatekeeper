using System;
using System.Runtime.Serialization;

namespace WpGatekeeper.Models
{
    [DataContract]
    public class Response
    {
        [DataMember(Name = "error")]
        public string ErrorString
        {
            get
            {
                return Error.ToString();
            }
            set {
                switch (value.ToLower())
                {
                    case "true":
                        Error = true;
                        break;
                    case "false":
                        Error = false;
                        break;
                    default:
                        throw (new ArgumentException("Invalid error"));
                }
            }
        }
        public bool Error { get; set; }

        [DataMember(Name = "success")]
        public string Success { get; set; }
    }
}
