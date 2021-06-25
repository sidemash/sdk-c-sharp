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


using LanguageExt;
using Newtonsoft.Json.Linq;
using System;
using static LanguageExt.Prelude;

namespace Sidemash.Sdk
{
    public abstract class Hook {
        internal Hook() {}
    
        public class HttpCall : Hook, IEquatable<HttpCall> {
            public HttpMethod Method { get; }
            public string Url { get; }
    
            public static readonly string RemoteType = "Hook.HttpCall";
    
            public HttpCall(HttpMethod method, string url) {
                Method = method;
                Url = url;
            }
    
            public override string GetRemoteType() { return RemoteType; } 
    
            public HttpCall WithMethod(HttpMethod method)
            {
                if(method == null) throw new ArgumentNullException(nameof(method));
                return new HttpCall(method, Url);
            }
    
            public HttpCall WithUrl(string url)
            {
                return new HttpCall(Method, url);
            }
    
            public static HttpCall FromJson(JToken json)
            {
                return new HttpCall(HttpMethod.FromJson(json["method"]),
                                    json["url"].ToString());
            }
    
            public string ToJson()
            {
                return ToJToken().ToString();
            }
    
            public override JToken ToJToken()
            {
                JObject json = new JObject();
                json.Add("method", Method.ToJson());
                json.Add("url", Url);
                return json;
            }
    
            public override bool Equals(object o)
            {
                return Equals(o as HttpCall);
            }
    
            public bool Equals(HttpCall other)
            {
                return other != null &&
                       Method.Equals(other.Method) &&
                       Url == other.Url;
            }
    
            public override int GetHashCode()
            {
                return (Method, Url).GetHashCode();
            }
    
            public override string ToString() => 
                "HttpCall{Method=" + Method +
                         ", Url=" + Url + '}';
        }
    
        public class WsCall : Hook, IEquatable<WsCall> {
            public HttpMethod Method { get; }
            public string Url { get; }
    
            public static readonly string RemoteType = "Hook.WsCall";
    
            public WsCall(HttpMethod method, string url) {
                Method = method;
                Url = url;
            }
    
            public override string GetRemoteType() { return RemoteType; } 
    
            public WsCall WithMethod(HttpMethod method)
            {
                if(method == null) throw new ArgumentNullException(nameof(method));
                return new WsCall(method, Url);
            }
    
            public WsCall WithUrl(string url)
            {
                return new WsCall(Method, url);
            }
    
            public static WsCall FromJson(JToken json)
            {
                return new WsCall(HttpMethod.FromJson(json["method"]),
                                  json["url"].ToString());
            }
    
            public string ToJson()
            {
                return ToJToken().ToString();
            }
    
            public override JToken ToJToken()
            {
                JObject json = new JObject();
                json.Add("method", Method.ToJson());
                json.Add("url", Url);
                return json;
            }
    
            public override bool Equals(object o)
            {
                return Equals(o as WsCall);
            }
    
            public bool Equals(WsCall other)
            {
                return other != null &&
                       Method.Equals(other.Method) &&
                       Url == other.Url;
            }
    
            public override int GetHashCode()
            {
                return (Method, Url).GetHashCode();
            }
    
            public override string ToString() => 
                "WsCall{Method=" + Method +
                       ", Url=" + Url + '}';
        }
    
        public abstract string GetRemoteType(); 
    
        public static Hook FromJson(JToken json)
        {
            string ty = json["_type"].ToString();
            if(ty == HttpCall.RemoteType) return HttpCall.FromJson(json);
            else if(ty == WsCall.RemoteType) return WsCall.FromJson(json);
            throw new ArgumentException("Invalid json submitted to create 'Hook'. Received Unexpected '_type' = " + ty);
        }
    
        public string ToJson()
        {
            return ToJToken().ToString();
        }
    
        public abstract JToken ToJToken();
    
        public static readonly Set<string> AllPossiblesTypes = Set(HttpCall.RemoteType, WsCall.RemoteType);
    
        public bool IsNotHttpCall()
        {
            return !GetRemoteType().Equals(HttpCall.RemoteType); 
        }
    
        public bool IsNotWsCall()
        {
            return !GetRemoteType().Equals(WsCall.RemoteType); 
        }
    
        public bool IsHttpCall()
        {
            return GetRemoteType().Equals(HttpCall.RemoteType); 
        }
    
        public bool IsWsCall()
        {
            return GetRemoteType().Equals(WsCall.RemoteType); 
        }
    
        public Option<HttpCall> AsHttpCallOption()
        {
            return IsHttpCall() ? Some((HttpCall) this) : None;
        }
    
        public Option<WsCall> AsWsCallOption()
        {
            return IsWsCall() ? Some((WsCall) this) : None;
        }
    
        public void IfHttpCall(Action<HttpCall> fn)
        {
            if(IsHttpCall()) fn((HttpCall) this);
        }
    
        public void IfWsCall(Action<WsCall> fn)
        {
            if(IsWsCall()) fn((WsCall) this);
        }
    
        public void IfNotHttpCall(Action<Hook> fn)
        {
            if(IsNotHttpCall()) fn(this);
        }
    
        public void IfNotWsCall(Action<Hook> fn)
        {
            if(IsNotWsCall()) fn(this);
        }
    }
}