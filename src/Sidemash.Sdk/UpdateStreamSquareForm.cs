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
using Map = LanguageExt.Map;
using Newtonsoft.Json.Linq;
using System;
using static LanguageExt.Prelude;

namespace Sidemash.Sdk
{
    public class UpdateStreamSquareForm : IEquatable<UpdateStreamSquareForm> {
        public string Id { get; }
        private Map<EditableFields, object> Set { get; }
        private Set<RemovableFields> Remove { get; }
    
        public enum RemovableFields { Description, ForeignData }
        public enum EditableFields { IsElastic, Size, Hook, Description, ForeignData }
    
        public UpdateStreamSquareForm(Builder builder) {
            if(builder == null) throw new ArgumentNullException(nameof(builder));
            Id     = builder.Id;
            Set    = builder.Set;
            Remove = builder.Remove;
        }
    
        public static Builder ById(string id)
        {
            if(id == null) throw new ArgumentNullException(nameof(id));
            return new Builder(id); 
        }
    
        public class Builder {
            internal string Id ;
            internal Set<RemovableFields> Remove ;
            internal Map<EditableFields, object> Set ;
    
            internal Builder(string id) : this(id, Set<RemovableFields>(), Map.empty<EditableFields, object>()) {}
            internal Builder(string id, Set<RemovableFields> remove, Map<EditableFields, object> set) {
                Id = id;
                Remove = remove;
                Set = set;
            }
    
            public Builder RemoveDescription()
            {
                Remove.Add(RemovableFields.Description);
                return this;
            }
    
            public Builder RemoveForeignData()
            {
                Remove.Add(RemovableFields.ForeignData);
                return this;
            }
    
            public Builder SetIsElastic(bool i)
            {
                Optional(i).IfSome(value => Set.Add(EditableFields.IsElastic, value));
                return this;
            }
    
            public Builder SetIsElasticOption(Option<bool> i)
            {
                Optional(i).Flatten().IfSome(value => Set.Add(EditableFields.IsElastic, value)); 
                return this;
            }
    
            public Builder SetSize(StreamSquareSize s)
            {
                Optional(s).IfSome(value => Set.Add(EditableFields.Size, value));
                return this;
            }
    
            public Builder SetSizeOption(Option<StreamSquareSize> s)
            {
                Optional(s).Flatten().IfSome(value => Set.Add(EditableFields.Size, value)); 
                return this;
            }
    
            public Builder SetHook(Hook h)
            {
                Optional(h).IfSome(value => Set.Add(EditableFields.Hook, value));
                return this;
            }
    
            public Builder SetHookOption(Option<Hook> h)
            {
                Optional(h).Flatten().IfSome(value => Set.Add(EditableFields.Hook, value)); 
                return this;
            }
    
            public Builder SetDescription(string d)
            {
                Optional(d).IfSome(value => Set.Add(EditableFields.Description, value));
                return this;
            }
    
            public Builder SetDescriptionOption(Option<string> d)
            {
                Optional(d).Flatten().IfSome(value => Set.Add(EditableFields.Description, value)); 
                return this;
            }
    
            public Builder SetForeignData(string f)
            {
                Optional(f).IfSome(value => Set.Add(EditableFields.ForeignData, value));
                return this;
            }
    
            public Builder SetForeignDataOption(Option<string> f)
            {
                Optional(f).Flatten().IfSome(value => Set.Add(EditableFields.ForeignData, value)); 
                return this;
            }
    
            public UpdateStreamSquareForm Build()
            {
                return new UpdateStreamSquareForm(this);
            }
        }
    
        public string ToJson()
        {
            return ToJToken().ToString();
        }
    
        public JToken ToJToken()
        {
            JObject json = new JObject();
            json.Add("remove", new JArray(Remove));
            json.Add("set", new JObject(Set));
            return json;
        }
    
        public override bool Equals(object o)
        {
            return Equals(o as UpdateStreamSquareForm);
        }
    
        public bool Equals(UpdateStreamSquareForm other)
        {
            return other != null &&
                   Id == other.Id &&
                   Remove.Equals(other.Remove) &&
                   Set.Equals(other.Set);
        }
    
        public override int GetHashCode()
        {
            return (Id, Remove, Set).GetHashCode();
        }
    
        public override string ToString() => 
            "UpdateStreamSquareForm{Id=" + Id +
                                   ", Remove=" + Remove +
                                   ", Set=" + Set + '}';
    }
}