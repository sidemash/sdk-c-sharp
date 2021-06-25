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
    public class PublishRtmp : IEquatable<PublishRtmp> {
        public string StreamKeyPrefix { get; }
        public SecureAndNonSecure Ip { get; }
        public SecureAndNonSecure Domain { get; }
    
        public static readonly string RemoteType = "PublishRtmp";
    
        public PublishRtmp(string streamKeyPrefix,
                           SecureAndNonSecure ip,
                           SecureAndNonSecure domain) {
            StreamKeyPrefix = streamKeyPrefix;
            Ip = ip;
            Domain = domain;
        }
    
        public string GetRemoteType() { return RemoteType; } 
    
        public PublishRtmp WithStreamKeyPrefix(string streamKeyPrefix)
        {
            return new PublishRtmp(streamKeyPrefix, Ip, Domain);
        }
    
        public PublishRtmp WithIp(SecureAndNonSecure ip)
        {
            if(ip == null) throw new ArgumentNullException(nameof(ip));
            return new PublishRtmp(StreamKeyPrefix, ip, Domain);
        }
    
        public PublishRtmp WithDomain(SecureAndNonSecure domain)
        {
            if(domain == null) throw new ArgumentNullException(nameof(domain));
            return new PublishRtmp(StreamKeyPrefix, Ip, domain);
        }
    
        public static PublishRtmp FromJson(JToken json)
        {
            return new PublishRtmp(json["streamKeyPrefix"].ToString(),
                                   SecureAndNonSecure.FromJson(json["ip"]),
                                   SecureAndNonSecure.FromJson(json["domain"]));
        }
    
        public string ToJson()
        {
            return ToJToken().ToString();
        }
    
        public JToken ToJToken()
        {
            JObject json = new JObject();
            json.Add("streamKeyPrefix", StreamKeyPrefix);
            json.Add("ip", Ip.ToJson());
            json.Add("domain", Domain.ToJson());
            return json;
        }
    
        public override bool Equals(object o)
        {
            return Equals(o as PublishRtmp);
        }
    
        public bool Equals(PublishRtmp other)
        {
            return other != null &&
                   StreamKeyPrefix == other.StreamKeyPrefix &&
                   Ip.Equals(other.Ip) &&
                   Domain.Equals(other.Domain);
        }
    
        public override int GetHashCode()
        {
            return (StreamKeyPrefix, Ip, Domain).GetHashCode();
        }
    
        public override string ToString() => 
            "PublishRtmp{StreamKeyPrefix=" + StreamKeyPrefix +
                        ", Ip=" + Ip +
                        ", Domain=" + Domain + '}';
    }
}