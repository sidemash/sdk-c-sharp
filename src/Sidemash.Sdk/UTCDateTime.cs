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
    public class UTCDateTime : IEquatable<UTCDateTime> {
        public string Iso8601 { get; }
        public Timestamp Timestamp { get; }
    
        public static readonly string RemoteType = "UTCDateTime";
    
        public UTCDateTime(string iso8601, Timestamp timestamp) {
            Iso8601 = iso8601;
            Timestamp = timestamp;
        }
    
        public string GetRemoteType() { return RemoteType; } 
    
        public UTCDateTime WithIso8601(string iso8601)
        {
            return new UTCDateTime(iso8601, Timestamp);
        }
    
        public UTCDateTime WithTimestamp(Timestamp timestamp)
        {
            if(timestamp == null) throw new ArgumentNullException(nameof(timestamp));
            return new UTCDateTime(Iso8601, timestamp);
        }
    
        public static UTCDateTime FromJson(JToken json)
        {
            return new UTCDateTime(json["iso8601"].ToString(),
                                   Timestamp.FromJson(json["timestamp"]));
        }
    
        public string ToJson()
        {
            return ToJToken().ToString();
        }
    
        public JToken ToJToken()
        {
            JObject json = new JObject();
            json.Add("iso8601", Iso8601);
            json.Add("timestamp", Timestamp.ToJson());
            return json;
        }
    
        public override bool Equals(object o)
        {
            return Equals(o as UTCDateTime);
        }
    
        public bool Equals(UTCDateTime other)
        {
            return other != null &&
                   Iso8601 == other.Iso8601 &&
                   Timestamp.Equals(other.Timestamp);
        }
    
        public override int GetHashCode()
        {
            return (Iso8601, Timestamp).GetHashCode();
        }
    
        public override string ToString() => 
            "UTCDateTime{Iso8601=" + Iso8601 +
                        ", Timestamp=" + Timestamp + '}';
    }
}