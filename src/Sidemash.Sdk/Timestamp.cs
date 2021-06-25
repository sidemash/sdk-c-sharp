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
    public class Timestamp : IEquatable<Timestamp> {
        public long Seconds { get; }
    
        public static readonly string RemoteType = "Timestamp";
    
        public Timestamp(long seconds) {
            Seconds = seconds;
        }
    
        public string GetRemoteType() { return RemoteType; } 
    
        public Timestamp WithSeconds(long seconds)
        {
            return new Timestamp(seconds);
        }
    
        public static Timestamp FromJson(JToken json)
        {
            return new Timestamp(json["seconds"].ToObject<long>());
        }
    
        public string ToJson()
        {
            return ToJToken().ToString();
        }
    
        public JToken ToJToken()
        {
            JObject json = new JObject();
            json.Add("seconds", Seconds);
            return json;
        }
    
        public override bool Equals(object o)
        {
            return Equals(o as Timestamp);
        }
    
        public bool Equals(Timestamp other)
        {
            return other != null &&
                   Seconds == other.Seconds;
        }
    
        public override int GetHashCode()
        {
            return Seconds.GetHashCode();
        }
    
        public override string ToString() => 
            "Timestamp{Seconds=" + Seconds + '}';
    }
}