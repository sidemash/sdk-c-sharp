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
    public class ListForm : IEquatable<ListForm> {
        public Option<string> Where { get; }
        public Option<int> Limit { get; }
        public Option<string> OrderBy { get; }
    
        public static readonly string RemoteType = "ListForm";
    
        public ListForm(Option<string> where, Option<int> limit, Option<string> orderBy) {
            Where = where;
            Limit = limit;
            OrderBy = orderBy;
        }
    
        public string GetRemoteType() { return RemoteType; } 
    
        public ListForm WithWhere(string where)
        {
            if(where == null) throw new ArgumentNullException(nameof(where));
            return new ListForm(Optional(where), Limit, OrderBy);
        }
    
        public ListForm WithLimit(int limit)
        {
            if(limit == null) throw new ArgumentNullException(nameof(limit));
            return new ListForm(Where, Optional(limit), OrderBy);
        }
    
        public ListForm WithOrderBy(string orderBy)
        {
            if(orderBy == null) throw new ArgumentNullException(nameof(orderBy));
            return new ListForm(Where, Limit, Optional(orderBy));
        }
    
        public static ListForm FromJson(JToken json)
        {
            return new ListForm(json["where"] == null ? None : Some(json["where"].ToString()),
                                json["limit"] == null ? None : Some(json["limit"].ToObject<int>()),
                                json["orderBy"] == null ? None : Some(json["orderBy"].ToString()));
        }
    
        public string ToJson()
        {
            return ToJToken().ToString();
        }
    
        public JToken ToJToken()
        {
            JObject json = new JObject();
            Where.IfSome(value => json.Add("where", value));
            Limit.IfSome(value => json.Add("limit", value));
            OrderBy.IfSome(value => json.Add("orderBy", value));
            return json;
        }
    
        public string ToQueryString()
        {
            if (Where.IsNone && Limit.IsNone && OrderBy.IsNone) return "";
            return "?" + string.Join("&", Where.ToList()
                .Append(Limit.Select(l => l.ToString()).ToList())
                .Append(OrderBy.ToList()));
        }

        public Option<string> ToQueryStringOption()
        {
            string qs = ToQueryString();
            if (qs.Length == 0) return None;
            return Some(qs);
        }

    
        public override bool Equals(object o)
        {
            return Equals(o as ListForm);
        }
    
        public bool Equals(ListForm other)
        {
            return other != null &&
                   Where.Equals(other.Where) &&
                   Limit.Equals(other.Limit) &&
                   OrderBy.Equals(other.OrderBy);
        }
    
        public override int GetHashCode()
        {
            return (Where, Limit, OrderBy).GetHashCode();
        }
    
        public override string ToString() => 
            "ListForm{Where=" + Where +
                     ", Limit=" + Limit +
                     ", OrderBy=" + OrderBy + '}';
    }
}