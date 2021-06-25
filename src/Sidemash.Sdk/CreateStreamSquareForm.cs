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
    public class CreateStreamSquareForm : IEquatable<CreateStreamSquareForm> {
        public bool IsElastic { get; }
        public StreamSquareSize Size { get; }
        public Hook Hook { get; }
        public Option<string> Description { get; }
        public Option<string> ForeignData { get; }
        public Option<string> PlayDomainName { get; }
        public Option<string> PublishDomainName { get; }
    
        public static readonly string RemoteType = "CreateStreamSquareForm";
    
        public CreateStreamSquareForm(bool isElastic,
                                      StreamSquareSize size,
                                      Hook hook,
                                      Option<string> description,
                                      Option<string> foreignData,
                                      Option<string> playDomainName,
                                      Option<string> publishDomainName) {
            IsElastic = isElastic;
            Size = size;
            Hook = hook;
            Description = description;
            ForeignData = foreignData;
            PlayDomainName = playDomainName;
            PublishDomainName = publishDomainName;
        }
    
        public string GetRemoteType() { return RemoteType; } 
    
        public CreateStreamSquareForm WithIsElastic(bool isElastic)
        {
            return new CreateStreamSquareForm(isElastic, Size, Hook, Description, ForeignData,
                                              PlayDomainName, PublishDomainName);
        }
    
        public CreateStreamSquareForm WithSize(StreamSquareSize size)
        {
            if(size == null) throw new ArgumentNullException(nameof(size));
            return new CreateStreamSquareForm(IsElastic, size, Hook, Description, ForeignData,
                                              PlayDomainName, PublishDomainName);
        }
    
        public CreateStreamSquareForm WithHook(Hook hook)
        {
            if(hook == null) throw new ArgumentNullException(nameof(hook));
            return new CreateStreamSquareForm(IsElastic, Size, hook, Description, ForeignData,
                                              PlayDomainName, PublishDomainName);
        }
    
        public CreateStreamSquareForm WithDescription(string description)
        {
            if(description == null) throw new ArgumentNullException(nameof(description));
            return new CreateStreamSquareForm(IsElastic, Size, Hook, Optional(description), ForeignData,
                                              PlayDomainName, PublishDomainName);
        }
    
        public CreateStreamSquareForm WithForeignData(string foreignData)
        {
            if(foreignData == null) throw new ArgumentNullException(nameof(foreignData));
            return new CreateStreamSquareForm(IsElastic, Size, Hook, Description, Optional(foreignData),
                                              PlayDomainName, PublishDomainName);
        }
    
        public CreateStreamSquareForm WithPlayDomainName(string playDomainName)
        {
            if(playDomainName == null) throw new ArgumentNullException(nameof(playDomainName));
            return new CreateStreamSquareForm(IsElastic, Size, Hook, Description, ForeignData,
                                              Optional(playDomainName), PublishDomainName);
        }
    
        public CreateStreamSquareForm WithPublishDomainName(string publishDomainName)
        {
            if(publishDomainName == null) throw new ArgumentNullException(nameof(publishDomainName));
            return new CreateStreamSquareForm(IsElastic, Size, Hook, Description, ForeignData,
                                              PlayDomainName, Optional(publishDomainName));
        }
    
        public static CreateStreamSquareForm FromJson(JToken json)
        {
            return new CreateStreamSquareForm(json["isElastic"].ToObject<bool>(),
                                              StreamSquareSize.FromJson(json["size"]),
                                              Hook.FromJson(json["hook"]),
                                              json["description"] == null ? None : Some(json["description"].ToString()),
                                              json["foreignData"] == null ? None : Some(json["foreignData"].ToString()),
                                              json["playDomainName"] == null ? None : Some(json["playDomainName"].ToString()),
                                              json["publishDomainName"] == null ? None : Some(json["publishDomainName"].ToString()));
        }
    
        public string ToJson()
        {
            return ToJToken().ToString();
        }
    
        public JToken ToJToken()
        {
            JObject json = new JObject();
            json.Add("isElastic", IsElastic);
            json.Add("size", Size.ToJson());
            json.Add("hook", Hook.ToJson());
            Description.IfSome(value => json.Add("description", value));
            ForeignData.IfSome(value => json.Add("foreignData", value));
            PlayDomainName.IfSome(value => json.Add("playDomainName", value));
            PublishDomainName.IfSome(value => json.Add("publishDomainName", value));
            return json;
        }
    
        public override bool Equals(object o)
        {
            return Equals(o as CreateStreamSquareForm);
        }
    
        public bool Equals(CreateStreamSquareForm other)
        {
            return other != null &&
                   IsElastic == other.IsElastic &&
                   Size.Equals(other.Size) &&
                   Hook.Equals(other.Hook) &&
                   Description.Equals(other.Description) &&
                   ForeignData.Equals(other.ForeignData) &&
                   PlayDomainName.Equals(other.PlayDomainName) &&
                   PublishDomainName.Equals(other.PublishDomainName);
        }
    
        public override int GetHashCode()
        {
            return (IsElastic, Size, Hook, Description, ForeignData,
                    PlayDomainName, PublishDomainName).GetHashCode();
        }
    
        public override string ToString() => 
            "CreateStreamSquareForm{IsElastic=" + IsElastic +
                                   ", Size=" + Size +
                                   ", Hook=" + Hook +
                                   ", Description=" + Description +
                                   ", ForeignData=" + ForeignData +
                                   ", PlayDomainName=" + PlayDomainName +
                                   ", PublishDomainName=" + PublishDomainName + '}';
    }
}