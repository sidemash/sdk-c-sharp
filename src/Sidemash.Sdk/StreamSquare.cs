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
    public class StreamSquare : IEquatable<StreamSquare> {
        public string Id { get; }
        public string Url { get; }
        public InstanceStatus Status { get; }
        public bool IsElastic { get; }
        public StreamSquareSize Size { get; }
        public Option<string> PlayDomainName { get; }
        public Option<string> PublishDomainName { get; }
        public Publish Publish { get; }
        public Hook Hook { get; }
        public Option<string> Description { get; }
        public Option<string> ForeignData { get; }
    
        public static readonly string RemoteType = "StreamSquare";
    
        public StreamSquare(string id,
                            string url,
                            InstanceStatus status,
                            bool isElastic,
                            StreamSquareSize size,
                            Option<string> playDomainName,
                            Option<string> publishDomainName,
                            Publish publish,
                            Hook hook,
                            Option<string> description,
                            Option<string> foreignData) {
            Id = id;
            Url = url;
            Status = status;
            IsElastic = isElastic;
            Size = size;
            PlayDomainName = playDomainName;
            PublishDomainName = publishDomainName;
            Publish = publish;
            Hook = hook;
            Description = description;
            ForeignData = foreignData;
        }
    
        public string GetRemoteType() { return RemoteType; } 
    
        public StreamSquare WithId(string id)
        {
            return new StreamSquare(id, Url, Status, IsElastic, Size, PlayDomainName, PublishDomainName,
                                    Publish, Hook, Description, ForeignData);
        }
    
        public StreamSquare WithUrl(string url)
        {
            return new StreamSquare(Id, url, Status, IsElastic, Size, PlayDomainName, PublishDomainName,
                                    Publish, Hook, Description, ForeignData);
        }
    
        public StreamSquare WithStatus(InstanceStatus status)
        {
            if(status == null) throw new ArgumentNullException(nameof(status));
            return new StreamSquare(Id, Url, status, IsElastic, Size, PlayDomainName, PublishDomainName,
                                    Publish, Hook, Description, ForeignData);
        }
    
        public StreamSquare WithIsElastic(bool isElastic)
        {
            return new StreamSquare(Id, Url, Status, isElastic, Size, PlayDomainName, PublishDomainName,
                                    Publish, Hook, Description, ForeignData);
        }
    
        public StreamSquare WithSize(StreamSquareSize size)
        {
            if(size == null) throw new ArgumentNullException(nameof(size));
            return new StreamSquare(Id, Url, Status, IsElastic, size, PlayDomainName, PublishDomainName,
                                    Publish, Hook, Description, ForeignData);
        }
    
        public StreamSquare WithPlayDomainName(string playDomainName)
        {
            if(playDomainName == null) throw new ArgumentNullException(nameof(playDomainName));
            return new StreamSquare(Id, Url, Status, IsElastic, Size, Optional(playDomainName),
                                    PublishDomainName, Publish, Hook, Description, ForeignData);
        }
    
        public StreamSquare WithPublishDomainName(string publishDomainName)
        {
            if(publishDomainName == null) throw new ArgumentNullException(nameof(publishDomainName));
            return new StreamSquare(Id, Url, Status, IsElastic, Size, PlayDomainName, Optional(publishDomainName),
                                    Publish, Hook, Description, ForeignData);
        }
    
        public StreamSquare WithPublish(Publish publish)
        {
            if(publish == null) throw new ArgumentNullException(nameof(publish));
            return new StreamSquare(Id, Url, Status, IsElastic, Size, PlayDomainName, PublishDomainName,
                                    publish, Hook, Description, ForeignData);
        }
    
        public StreamSquare WithHook(Hook hook)
        {
            if(hook == null) throw new ArgumentNullException(nameof(hook));
            return new StreamSquare(Id, Url, Status, IsElastic, Size, PlayDomainName, PublishDomainName,
                                    Publish, hook, Description, ForeignData);
        }
    
        public StreamSquare WithDescription(string description)
        {
            if(description == null) throw new ArgumentNullException(nameof(description));
            return new StreamSquare(Id, Url, Status, IsElastic, Size, PlayDomainName, PublishDomainName,
                                    Publish, Hook, Optional(description), ForeignData);
        }
    
        public StreamSquare WithForeignData(string foreignData)
        {
            if(foreignData == null) throw new ArgumentNullException(nameof(foreignData));
            return new StreamSquare(Id, Url, Status, IsElastic, Size, PlayDomainName, PublishDomainName,
                                    Publish, Hook, Description, Optional(foreignData));
        }
    
        public static StreamSquare FromJson(JToken json)
        {
            return new StreamSquare(json["id"].ToString(),
                                    json["url"].ToString(),
                                    InstanceStatus.FromJson(json["status"]),
                                    json["isElastic"].ToObject<bool>(),
                                    StreamSquareSize.FromJson(json["size"]),
                                    json["playDomainName"] == null ? None : Some(json["playDomainName"].ToString()),
                                    json["publishDomainName"] == null ? None : Some(json["publishDomainName"].ToString()),
                                    Publish.FromJson(json["publish"]),
                                    Hook.FromJson(json["hook"]),
                                    json["description"] == null ? None : Some(json["description"].ToString()),
                                    json["foreignData"] == null ? None : Some(json["foreignData"].ToString()));
        }
    
        public string ToJson()
        {
            return ToJToken().ToString();
        }
    
        public JToken ToJToken()
        {
            JObject json = new JObject();
            json.Add("id", Id);
            json.Add("url", Url);
            json.Add("status", Status.ToJson());
            json.Add("isElastic", IsElastic);
            json.Add("size", Size.ToJson());
            PlayDomainName.IfSome(value => json.Add("playDomainName", value));
            PublishDomainName.IfSome(value => json.Add("publishDomainName", value));
            json.Add("publish", Publish.ToJson());
            json.Add("hook", Hook.ToJson());
            Description.IfSome(value => json.Add("description", value));
            ForeignData.IfSome(value => json.Add("foreignData", value));
            return json;
        }
    
        public override bool Equals(object o)
        {
            return Equals(o as StreamSquare);
        }
    
        public bool Equals(StreamSquare other)
        {
            return other != null &&
                   Id == other.Id &&
                   Url == other.Url &&
                   Status.Equals(other.Status) &&
                   IsElastic == other.IsElastic &&
                   Size.Equals(other.Size) &&
                   PlayDomainName.Equals(other.PlayDomainName) &&
                   PublishDomainName.Equals(other.PublishDomainName) &&
                   Publish.Equals(other.Publish) &&
                   Hook.Equals(other.Hook) &&
                   Description.Equals(other.Description) &&
                   ForeignData.Equals(other.ForeignData);
        }
    
        public override int GetHashCode()
        {
            return (Id, Url, Status, IsElastic, Size, PlayDomainName,
                    PublishDomainName, Publish, Hook, Description,
                    ForeignData).GetHashCode();
        }
    
        public override string ToString() => 
            "StreamSquare{Id=" + Id +
                         ", Url=" + Url +
                         ", Status=" + Status +
                         ", IsElastic=" + IsElastic +
                         ", Size=" + Size +
                         ", PlayDomainName=" + PlayDomainName +
                         ", PublishDomainName=" + PublishDomainName +
                         ", Publish=" + Publish +
                         ", Hook=" + Hook +
                         ", Description=" + Description +
                         ", ForeignData=" + ForeignData + '}';
    }
}