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
    public class Auth : IEquatable<Auth> {
        public string Token { get; }
        public string SecretKey { get; }
    
        public static readonly string RemoteType = "Auth";
    
        public Auth(string token, string secretKey) {
            Token = token;
            SecretKey = secretKey;
        }
    
        public string GetRemoteType() { return RemoteType; } 
    
        public Auth WithToken(string token)
        {
            return new Auth(token, SecretKey);
        }
    
        public Auth WithSecretKey(string secretKey)
        {
            return new Auth(Token, secretKey);
        }
    
        public static Auth FromJson(JToken json)
        {
            return new Auth(json["token"].ToString(),
                            json["secretKey"].ToString());
        }
    
        public string ToJson()
        {
            return ToJToken().ToString();
        }
    
        public JToken ToJToken()
        {
            JObject json = new JObject();
            json.Add("token", Token);
            json.Add("secretKey", SecretKey);
            return json;
        }
    
        public override bool Equals(object o)
        {
            return Equals(o as Auth);
        }
    
        public bool Equals(Auth other)
        {
            return other != null &&
                   Token == other.Token &&
                   SecretKey == other.SecretKey;
        }
    
        public override int GetHashCode()
        {
            return (Token, SecretKey).GetHashCode();
        }
    
        public override string ToString() => 
            "Auth{Token=" + Token +
                 ", SecretKey=******" + '}';
    }
}