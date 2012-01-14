using System;
using System.Runtime.Serialization;

namespace WpGatekeeper.Models
{
    [DataContract]
    public class Response
    {
        [DataMember(Name = "error")]
        public string Error { get; set; }

        [DataMember(Name = "success")]
        public string SuccessString
        {
            get
            {
                return Success.ToString();
            }
            set
            {
                switch (value.ToLower())
                {
                    case "true":
                        Success = true;
                        break;
                    case "false":
                        Success = false;
                        break;
                    default:
                        throw (new ArgumentException("Invalid success value"));
                }
            }
        }
        public bool Success { get; set; }
    }
}
