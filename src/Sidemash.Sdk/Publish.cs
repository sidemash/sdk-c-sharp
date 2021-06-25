/*
   Copyright © 2020 Sidemash Cloud Services

   Licensed under the Apache  License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless  required  by  applicable  law  or  agreed to in writing,
   software  distributed  under  the  License  is distributed on an
   "AS IS"  BASIS, WITHOUT  WARRANTIES  OR CONDITIONS OF  ANY KIND,
   either  express  or  implied.  See the License for the  specific
   language governing permissions and limitations under the License.
*/


using Newtonsoft.Json.Linq;
using System;

namespace Sidemash.Sdk
{
    public class Publish : IEquatable<Publish> {
        public PublishRtmp Rtmp { get; }
    
        public static readonly string RemoteType = "Publish";
    
        public Publish(PublishRtmp rtmp) {
            Rtmp = rtmp;
        }
    
        public string GetRemoteType() { return RemoteType; } 
    
        public Publish WithRtmp(PublishRtmp rtmp)
        {
            if(rtmp == null) throw new ArgumentNullException(nameof(rtmp));
            return new Publish(rtmp);
        }
    
        public static Publish FromJson(JToken json)
        {
            return new Publish(PublishRtmp.FromJson(json["rtmp"]));
        }
    
        public string ToJson()
        {
            return ToJToken().ToString();
        }
    
        public JToken ToJToken()
        {
            JObject json = new JObject();
            json.Add("rtmp", Rtmp.ToJson());
            return json;
        }
    
        public override bool Equals(object o)
        {
            return Equals(o as Publish);
        }
    
        public bool Equals(Publish other)
        {
            return other != null &&
                   Rtmp.Equals(other.Rtmp);
        }
    
        public override int GetHashCode()
        {
            return Rtmp.GetHashCode();
        }
    
        public override string ToString() => 
            "Publish{Rtmp=" + Rtmp + '}';
    }
}