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
    public class HttpMethod : IEquatable<HttpMethod> {
        private string Value { get; }
    
        internal HttpMethod(string value) {
            Value = value;
        }
    
        public class GetT : HttpMethod
        {
            public GetT() : base("GET") { }
        }
    
        public class PostT : HttpMethod
        {
            public PostT() : base("POST") { }
        }
    
        public class PutT : HttpMethod
        {
            public PutT() : base("PUT") { }
        }
    
        public class DeleteT : HttpMethod
        {
            public DeleteT() : base("DELETE") { }
        }
    
        public class PatchT : HttpMethod
        {
            public PatchT() : base("PATCH") { }
        }
    
        public static readonly GetT GET = new GetT();
        public static readonly PostT POST = new PostT();
        public static readonly PutT PUT = new PutT();
        public static readonly DeleteT DELETE = new DeleteT();
        public static readonly PatchT PATCH = new PatchT();
    
        public static readonly Set<string> AllPossiblesValues = Set("GET", "POST", "PUT", "DELETE", "PATCH");
    
        public static Option<HttpMethod> FromString(string value)
        {
            if(value.Equals(GET.Value)) return Some<HttpMethod>(GET);
            if(value.Equals(POST.Value)) return Some<HttpMethod>(POST);
            if(value.Equals(PUT.Value)) return Some<HttpMethod>(PUT);
            if(value.Equals(DELETE.Value)) return Some<HttpMethod>(DELETE);
            if(value.Equals(PATCH.Value)) return Some<HttpMethod>(PATCH);
            return None;
        }
    
        public static bool IsValid(string value)
        {
            return AllPossiblesValues.Contains(value);
        }
    
        public static bool IsNotGET(string value)
        {
            return !value.Equals("GET");
        }
    
        public static bool IsNotPOST(string value)
        {
            return !value.Equals("POST");
        }
    
        public static bool IsNotPUT(string value)
        {
            return !value.Equals("PUT");
        }
    
        public static bool IsNotDELETE(string value)
        {
            return !value.Equals("DELETE");
        }
    
        public static bool IsNotPATCH(string value)
        {
            return !value.Equals("PATCH");
        }
    
        public static void IfNotGET(string value, Action<HttpMethod> fn)
        {
             if(IsNotGET(value)) fn(GET);
        }
    
        public static void IfNotPOST(string value, Action<HttpMethod> fn)
        {
             if(IsNotPOST(value)) fn(POST);
        }
    
        public static void IfNotPUT(string value, Action<HttpMethod> fn)
        {
             if(IsNotPUT(value)) fn(PUT);
        }
    
        public static void IfNotDELETE(string value, Action<HttpMethod> fn)
        {
             if(IsNotDELETE(value)) fn(DELETE);
        }
    
        public static void IfNotPATCH(string value, Action<HttpMethod> fn)
        {
             if(IsNotPATCH(value)) fn(PATCH);
        }
    
        public static bool IsGET(string value)
        {
            return value.Equals("GET");
        }
    
        public static bool IsPOST(string value)
        {
            return value.Equals("POST");
        }
    
        public static bool IsPUT(string value)
        {
            return value.Equals("PUT");
        }
    
        public static bool IsDELETE(string value)
        {
            return value.Equals("DELETE");
        }
    
        public static bool IsPATCH(string value)
        {
            return value.Equals("PATCH");
        }
    
        public static Option<GetT> AsGETOption(string value)
        {
             return IsGET(value) ? Some(GET) : None;
        }
    
        public static Option<PostT> AsPOSTOption(string value)
        {
             return IsPOST(value) ? Some(POST) : None;
        }
    
        public static Option<PutT> AsPUTOption(string value)
        {
             return IsPUT(value) ? Some(PUT) : None;
        }
    
        public static Option<DeleteT> AsDELETEOption(string value)
        {
             return IsDELETE(value) ? Some(DELETE) : None;
        }
    
        public static Option<PatchT> AsPATCHOption(string value)
        {
             return IsPATCH(value) ? Some(PATCH) : None;
        }
    
        public static void IfGET(string value, Action<GetT> fn)
        {
             if(IsGET(value)) fn(GET);
        }
    
        public static void IfPOST(string value, Action<PostT> fn)
        {
             if(IsPOST(value)) fn(POST);
        }
    
        public static void IfPUT(string value, Action<PutT> fn)
        {
             if(IsPUT(value)) fn(PUT);
        }
    
        public static void IfDELETE(string value, Action<DeleteT> fn)
        {
             if(IsDELETE(value)) fn(DELETE);
        }
    
        public static void IfPATCH(string value, Action<PatchT> fn)
        {
             if(IsPATCH(value)) fn(PATCH);
        }
    
        public bool IsValid()
        {
            return IsValid(this.Value);
        }
    
        public bool IsNotGET()
        {
            return IsNotGET(this.Value);
        }
    
        public bool IsNotPOST()
        {
            return IsNotPOST(this.Value);
        }
    
        public bool IsNotPUT()
        {
            return IsNotPUT(this.Value);
        }
    
        public bool IsNotDELETE()
        {
            return IsNotDELETE(this.Value);
        }
    
        public bool IsNotPATCH()
        {
            return IsNotPATCH(this.Value);
        }
    
        public void IfNotGET(Action<HttpMethod> fn)
        {
            IfNotGET(this.Value, fn);
        }
    
        public void IfNotPOST(Action<HttpMethod> fn)
        {
            IfNotPOST(this.Value, fn);
        }
    
        public void IfNotPUT(Action<HttpMethod> fn)
        {
            IfNotPUT(this.Value, fn);
        }
    
        public void IfNotDELETE(Action<HttpMethod> fn)
        {
            IfNotDELETE(this.Value, fn);
        }
    
        public void IfNotPATCH(Action<HttpMethod> fn)
        {
            IfNotPATCH(this.Value, fn);
        }
    
        public bool IsGET()
        {
            return IsGET(this.Value);
        }
    
        public bool IsPOST()
        {
            return IsPOST(this.Value);
        }
    
        public bool IsPUT()
        {
            return IsPUT(this.Value);
        }
    
        public bool IsDELETE()
        {
            return IsDELETE(this.Value);
        }
    
        public bool IsPATCH()
        {
            return IsPATCH(this.Value);
        }
    
        public Option<GetT> AsGETOption()
        {
             return AsGETOption(this.Value);
        }
    
        public Option<PostT> AsPOSTOption()
        {
             return AsPOSTOption(this.Value);
        }
    
        public Option<PutT> AsPUTOption()
        {
             return AsPUTOption(this.Value);
        }
    
        public Option<DeleteT> AsDELETEOption()
        {
             return AsDELETEOption(this.Value);
        }
    
        public Option<PatchT> AsPATCHOption()
        {
             return AsPATCHOption(this.Value);
        }
    
        public void IfGET(Action<GetT> fn)
        {
            IfGET(this.Value, fn);
        }
    
        public void IfPOST(Action<PostT> fn)
        {
            IfPOST(this.Value, fn);
        }
    
        public void IfPUT(Action<PutT> fn)
        {
            IfPUT(this.Value, fn);
        }
    
        public void IfDELETE(Action<DeleteT> fn)
        {
            IfDELETE(this.Value, fn);
        }
    
        public void IfPATCH(Action<PatchT> fn)
        {
            IfPATCH(this.Value, fn);
        }
    
        public static HttpMethod FromJson(JToken json)
        {
            return new HttpMethod(json.ToString());
        }
    
        public string ToJson()
        {
            return ToJToken().ToString();
        }
    
        public JToken ToJToken()
        {
            return new JValue(Value);
        }
    
        public override bool Equals(object o)
        {
            return Equals(o as HttpMethod);
        }
    
        public bool Equals(HttpMethod other)
        {
            return other != null &&
                   Value == other.Value;
        }
    
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    
        public override string ToString() => 
            Value;
    }
}