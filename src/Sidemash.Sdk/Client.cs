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
    public class Client : IEquatable<Client> {
        private Auth Auth { get; }
        public readonly StreamSquareService StreamSquare ;
    
        public Client(Auth auth) {
            Auth = auth;
            StreamSquare = new StreamSquareService(Auth);
        }
    
        public override bool Equals(object o)
        {
            return Equals(o as Client);
        }
    
        public bool Equals(Client other)
        {
            return other != null &&
                   Auth.Equals(other.Auth);
        }
    
        public override int GetHashCode()
        {
            return Auth.GetHashCode();
        }
    
        public override string ToString() => 
            "Client{Auth=" + Auth + '}';
    }
}