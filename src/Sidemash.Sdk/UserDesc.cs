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
    public class UserDesc : IEquatable<UserDesc> {
        public int Todo { get; }
    
        public static readonly string RemoteType = "UserDesc";
    
        public UserDesc(int todo) {
            Todo = todo;
        }
    
        public string GetRemoteType() { return RemoteType; } 
    
        public UserDesc WithTodo(int todo)
        {
            return new UserDesc(todo);
        }
    
        public static UserDesc FromJson(JToken json)
        {
            return new UserDesc(json["todo"].ToObject<int>());
        }
    
        public string ToJson()
        {
            return ToJToken().ToString();
        }
    
        public JToken ToJToken()
        {
            JObject json = new JObject();
            json.Add("todo", Todo);
            return json;
        }
    
        public override bool Equals(object o)
        {
            return Equals(o as UserDesc);
        }
    
        public bool Equals(UserDesc other)
        {
            return other != null &&
                   Todo == other.Todo;
        }
    
        public override int GetHashCode()
        {
            return Todo.GetHashCode();
        }
    
        public override string ToString() => 
            "UserDesc{Todo=" + Todo + '}';
    }
}