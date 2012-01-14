using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using WpGatekeeper.Models;
using System.Runtime.Serialization.Json;

namespace WpGatekeeper.Data
{
    public class GatekeeperService
    {
        public void FetchDoorStates(Action<List<Door>> callback)
        {
            HttpWebRequest request = WebRequest.CreateHttp(@"http://gatekeeper.csh.rit.edu/api/all_doors");
            request.Method = "POST";
            request.BeginGetRequestStream((reqResult) =>
            {
                Stream requestStream = request.EndGetRequestStream(reqResult);
                using (StreamWriter writer = new StreamWriter(requestStream))
                {

                }

                request.BeginGetResponse((resResult) =>
                {
                    Stream responseStream = request.EndGetResponse(resResult).GetResponseStream();
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Door>));
                    List<Door> temp = serializer.ReadObject(responseStream) as List<Door>;
                    callback(temp);
                }, null);
            }, null);
        }

        public void PopDoor(Door door, Action<Response> callback)
        {
            HttpWebRequest request = WebRequest.CreateHttp(String.Format("http://gatekeeper.csh.rit.edu/api/pop/{0}", door.Id));
            request.Method = "POST";
            request.BeginGetRequestStream((reqResult) =>
            {
                Stream requestStream = request.EndGetRequestStream(reqResult);
                using (StreamWriter writer = new StreamWriter(requestStream))
                {

                }

                request.BeginGetResponse((resResult) =>
                {
                    Stream responseStream = request.EndGetResponse(resResult).GetResponseStream();
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Response));
                    Response temp = serializer.ReadObject(responseStream) as Response;
                    callback(temp);
                }, null);
            }, null);
        }
    }
}
