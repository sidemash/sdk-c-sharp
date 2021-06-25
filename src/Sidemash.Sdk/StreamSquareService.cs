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


using Map = LanguageExt.Map;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System;
using static LanguageExt.Prelude;

namespace Sidemash.Sdk
{
    public class StreamSquareService : IEquatable<StreamSquareService> {
        private Auth Auth { get; }
    
        public StreamSquareService(Auth auth) {
            Auth = auth;
        }
    
        public Task<StreamSquare> Create(CreateStreamSquareForm form)
        {
            return Http.doPostAsync("/" + Sdk.Version + "/stream-squares", Map.empty<string, string>(), "", Some(form.ToJson()), StreamSquare.FromJson, Auth);
        }
    
        public Task<StreamSquare> Get(string id)
        {
            return Http.doGetAsync("/" + Sdk.Version + "/stream-squares/" + id, Map.empty<string, string>(), "", StreamSquare.FromJson, Auth);
        }
    
        public Task<RestCollection<StreamSquare>> List()
        {
            return Http.doListAsync<StreamSquare>("/" + Sdk.Version + "/stream-squares", Map.empty<string, string>(), "", StreamSquare.FromJson, Auth);
        }
    
        public Task<RestCollection<StreamSquare>> List(ListForm form)
        {
            return Http.doListAsync<StreamSquare>("/" + Sdk.Version + "/stream-squares", Map.empty<string, string>(), form.ToQueryString(), StreamSquare.FromJson, Auth);
        }
    
        public Task<StreamSquare> Update(UpdateStreamSquareForm form)
        {
            return Http.doPatchAsync("/" + Sdk.Version + "/stream-squares/" + form.Id, Map.empty<string, string>(), "", Some(form.ToJson()), StreamSquare.FromJson, Auth);
        }
    
        public async void Delete(string id)
        {
            await Http.doDeleteAsync("/" + Sdk.Version + "/stream-squares/" + id, Map.empty<string, string>(), "", None, js => js, Auth);
        }
    
        public override bool Equals(object o)
        {
            return Equals(o as StreamSquareService);
        }
    
        public bool Equals(StreamSquareService other)
        {
            return other != null &&
                   Auth.Equals(other.Auth);
        }
    
        public override int GetHashCode()
        {
            return Auth.GetHashCode();
        }
    
        public override string ToString() => 
            "StreamSquareService{Auth=" + Auth + '}';
    }
}