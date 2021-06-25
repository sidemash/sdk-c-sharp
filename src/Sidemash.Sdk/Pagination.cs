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
    public class Pagination : IEquatable<Pagination> {
        public string SelfUrl { get; }
        public Option<string> PrevUrl { get; }
        public Option<string> NextUrl { get; }
        public UTCDateTime StartedTime { get; }
        public int NbItemsOnThisPage { get; }
        public int Page { get; }
        public int NbItemsPerPage { get; }
    
        public static readonly string RemoteType = "Pagination";
    
        public Pagination(string selfUrl,
                          Option<string> prevUrl,
                          Option<string> nextUrl,
                          UTCDateTime startedTime,
                          int nbItemsOnThisPage,
                          int page,
                          int nbItemsPerPage) {
            SelfUrl = selfUrl;
            PrevUrl = prevUrl;
            NextUrl = nextUrl;
            StartedTime = startedTime;
            NbItemsOnThisPage = nbItemsOnThisPage;
            Page = page;
            NbItemsPerPage = nbItemsPerPage;
        }
    
        public string GetRemoteType() { return RemoteType; } 
    
        public Pagination WithSelfUrl(string selfUrl)
        {
            return new Pagination(selfUrl, PrevUrl, NextUrl, StartedTime, NbItemsOnThisPage,
                                  Page, NbItemsPerPage);
        }
    
        public Pagination WithPrevUrl(string prevUrl)
        {
            if(prevUrl == null) throw new ArgumentNullException(nameof(prevUrl));
            return new Pagination(SelfUrl, Optional(prevUrl), NextUrl, StartedTime, NbItemsOnThisPage,
                                  Page, NbItemsPerPage);
        }
    
        public Pagination WithNextUrl(string nextUrl)
        {
            if(nextUrl == null) throw new ArgumentNullException(nameof(nextUrl));
            return new Pagination(SelfUrl, PrevUrl, Optional(nextUrl), StartedTime, NbItemsOnThisPage,
                                  Page, NbItemsPerPage);
        }
    
        public Pagination WithStartedTime(UTCDateTime startedTime)
        {
            if(startedTime == null) throw new ArgumentNullException(nameof(startedTime));
            return new Pagination(SelfUrl, PrevUrl, NextUrl, startedTime, NbItemsOnThisPage,
                                  Page, NbItemsPerPage);
        }
    
        public Pagination WithNbItemsOnThisPage(int nbItemsOnThisPage)
        {
            return new Pagination(SelfUrl, PrevUrl, NextUrl, StartedTime, nbItemsOnThisPage,
                                  Page, NbItemsPerPage);
        }
    
        public Pagination WithPage(int page)
        {
            return new Pagination(SelfUrl, PrevUrl, NextUrl, StartedTime, NbItemsOnThisPage,
                                  page, NbItemsPerPage);
        }
    
        public Pagination WithNbItemsPerPage(int nbItemsPerPage)
        {
            return new Pagination(SelfUrl, PrevUrl, NextUrl, StartedTime, NbItemsOnThisPage,
                                  Page, nbItemsPerPage);
        }
    
        public static Pagination FromJson(JToken json)
        {
            return new Pagination(json["selfUrl"].ToString(),
                                  json["prevUrl"] == null ? None : Some(json["prevUrl"].ToString()),
                                  json["nextUrl"] == null ? None : Some(json["nextUrl"].ToString()),
                                  UTCDateTime.FromJson(json["startedTime"]),
                                  json["nbItemsOnThisPage"].ToObject<int>(),
                                  json["page"].ToObject<int>(),
                                  json["nbItemsPerPage"].ToObject<int>());
        }
    
        public string ToJson()
        {
            return ToJToken().ToString();
        }
    
        public JToken ToJToken()
        {
            JObject json = new JObject();
            json.Add("selfUrl", SelfUrl);
            PrevUrl.IfSome(value => json.Add("prevUrl", value));
            NextUrl.IfSome(value => json.Add("nextUrl", value));
            json.Add("startedTime", StartedTime.ToJson());
            json.Add("nbItemsOnThisPage", NbItemsOnThisPage);
            json.Add("page", Page);
            json.Add("nbItemsPerPage", NbItemsPerPage);
            return json;
        }
    
        public override bool Equals(object o)
        {
            return Equals(o as Pagination);
        }
    
        public bool Equals(Pagination other)
        {
            return other != null &&
                   SelfUrl == other.SelfUrl &&
                   PrevUrl.Equals(other.PrevUrl) &&
                   NextUrl.Equals(other.NextUrl) &&
                   StartedTime.Equals(other.StartedTime) &&
                   NbItemsOnThisPage == other.NbItemsOnThisPage &&
                   Page == other.Page &&
                   NbItemsPerPage == other.NbItemsPerPage;
        }
    
        public override int GetHashCode()
        {
            return (SelfUrl, PrevUrl, NextUrl, StartedTime, NbItemsOnThisPage,
                    Page, NbItemsPerPage).GetHashCode();
        }
    
        public override string ToString() => 
            "Pagination{SelfUrl=" + SelfUrl +
                       ", PrevUrl=" + PrevUrl +
                       ", NextUrl=" + NextUrl +
                       ", StartedTime=" + StartedTime +
                       ", NbItemsOnThisPage=" + NbItemsOnThisPage +
                       ", Page=" + Page +
                       ", NbItemsPerPage=" + NbItemsPerPage + '}';
    }
}