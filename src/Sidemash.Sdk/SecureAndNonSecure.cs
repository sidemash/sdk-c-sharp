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
    public class SecureAndNonSecure : IEquatable<SecureAndNonSecure> {
        public string Secure { get; }
        public string NonSecureOn80 { get; }
        public string NonSecure { get; }
    
        public static readonly string RemoteType = "SecureAndNonSecure";
    
        public SecureAndNonSecure(string secure, string nonSecureOn80, string nonSecure) {
            Secure = secure;
            NonSecureOn80 = nonSecureOn80;
            NonSecure = nonSecure;
        }
    
        public string GetRemoteType() { return RemoteType; } 
    
        public SecureAndNonSecure WithSecure(string secure)
        {
            return new SecureAndNonSecure(secure, NonSecureOn80, NonSecure);
        }
    
        public SecureAndNonSecure WithNonSecureOn80(string nonSecureOn80)
        {
            return new SecureAndNonSecure(Secure, nonSecureOn80, NonSecure);
        }
    
        public SecureAndNonSecure WithNonSecure(string nonSecure)
        {
            return new SecureAndNonSecure(Secure, NonSecureOn80, nonSecure);
        }
    
        public static SecureAndNonSecure FromJson(JToken json)
        {
            return new SecureAndNonSecure(json["secure"].ToString(),
                                          json["nonSecureOn80"].ToString(),
                                          json["nonSecure"].ToString());
        }
    
        public string ToJson()
        {
            return ToJToken().ToString();
        }
    
        public JToken ToJToken()
        {
            JObject json = new JObject();
            json.Add("secure", Secure);
            json.Add("nonSecureOn80", NonSecureOn80);
            json.Add("nonSecure", NonSecure);
            return json;
        }
    
        public override bool Equals(object o)
        {
            return Equals(o as SecureAndNonSecure);
        }
    
        public bool Equals(SecureAndNonSecure other)
        {
            return other != null &&
                   Secure == other.Secure &&
                   NonSecureOn80 == other.NonSecureOn80 &&
                   NonSecure == other.NonSecure;
        }
    
        public override int GetHashCode()
        {
            return (Secure, NonSecureOn80, NonSecure).GetHashCode();
        }
    
        public override string ToString() => 
            "SecureAndNonSecure{Secure=" + Secure +
                               ", NonSecureOn80=" + NonSecureOn80 +
                               ", NonSecure=" + NonSecure + '}';
    }
}