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
    public class StreamSquareSize : IEquatable<StreamSquareSize> {
        private string Value { get; }
    
        internal StreamSquareSize(string value) {
            Value = value;
        }
    
        public class ST : StreamSquareSize
        {
            public ST() : base("S") { }
        }
    
        public class MT : StreamSquareSize
        {
            public MT() : base("M") { }
        }
    
        public class LT : StreamSquareSize
        {
            public LT() : base("L") { }
        }
    
        public class XlT : StreamSquareSize
        {
            public XlT() : base("XL") { }
        }
    
        public class XxlT : StreamSquareSize
        {
            public XxlT() : base("XXL") { }
        }
    
        public static readonly ST S = new ST();
        public static readonly MT M = new MT();
        public static readonly LT L = new LT();
        public static readonly XlT XL = new XlT();
        public static readonly XxlT XXL = new XxlT();
    
        public static readonly Set<string> AllPossiblesValues = Set("S", "M", "L", "XL", "XXL");
    
        public static Option<StreamSquareSize> FromString(string value)
        {
            if(value.Equals(S.Value)) return Some<StreamSquareSize>(S);
            if(value.Equals(M.Value)) return Some<StreamSquareSize>(M);
            if(value.Equals(L.Value)) return Some<StreamSquareSize>(L);
            if(value.Equals(XL.Value)) return Some<StreamSquareSize>(XL);
            if(value.Equals(XXL.Value)) return Some<StreamSquareSize>(XXL);
            return None;
        }
    
        public static bool IsValid(string value)
        {
            return AllPossiblesValues.Contains(value);
        }
    
        public static bool IsNotS(string value)
        {
            return !value.Equals("S");
        }
    
        public static bool IsNotM(string value)
        {
            return !value.Equals("M");
        }
    
        public static bool IsNotL(string value)
        {
            return !value.Equals("L");
        }
    
        public static bool IsNotXL(string value)
        {
            return !value.Equals("XL");
        }
    
        public static bool IsNotXXL(string value)
        {
            return !value.Equals("XXL");
        }
    
        public static void IfNotS(string value, Action<StreamSquareSize> fn)
        {
             if(IsNotS(value)) fn(S);
        }
    
        public static void IfNotM(string value, Action<StreamSquareSize> fn)
        {
             if(IsNotM(value)) fn(M);
        }
    
        public static void IfNotL(string value, Action<StreamSquareSize> fn)
        {
             if(IsNotL(value)) fn(L);
        }
    
        public static void IfNotXL(string value, Action<StreamSquareSize> fn)
        {
             if(IsNotXL(value)) fn(XL);
        }
    
        public static void IfNotXXL(string value, Action<StreamSquareSize> fn)
        {
             if(IsNotXXL(value)) fn(XXL);
        }
    
        public static bool IsS(string value)
        {
            return value.Equals("S");
        }
    
        public static bool IsM(string value)
        {
            return value.Equals("M");
        }
    
        public static bool IsL(string value)
        {
            return value.Equals("L");
        }
    
        public static bool IsXL(string value)
        {
            return value.Equals("XL");
        }
    
        public static bool IsXXL(string value)
        {
            return value.Equals("XXL");
        }
    
        public static Option<ST> AsSOption(string value)
        {
             return IsS(value) ? Some(S) : None;
        }
    
        public static Option<MT> AsMOption(string value)
        {
             return IsM(value) ? Some(M) : None;
        }
    
        public static Option<LT> AsLOption(string value)
        {
             return IsL(value) ? Some(L) : None;
        }
    
        public static Option<XlT> AsXLOption(string value)
        {
             return IsXL(value) ? Some(XL) : None;
        }
    
        public static Option<XxlT> AsXXLOption(string value)
        {
             return IsXXL(value) ? Some(XXL) : None;
        }
    
        public static void IfS(string value, Action<ST> fn)
        {
             if(IsS(value)) fn(S);
        }
    
        public static void IfM(string value, Action<MT> fn)
        {
             if(IsM(value)) fn(M);
        }
    
        public static void IfL(string value, Action<LT> fn)
        {
             if(IsL(value)) fn(L);
        }
    
        public static void IfXL(string value, Action<XlT> fn)
        {
             if(IsXL(value)) fn(XL);
        }
    
        public static void IfXXL(string value, Action<XxlT> fn)
        {
             if(IsXXL(value)) fn(XXL);
        }
    
        public bool IsValid()
        {
            return IsValid(this.Value);
        }
    
        public bool IsNotS()
        {
            return IsNotS(this.Value);
        }
    
        public bool IsNotM()
        {
            return IsNotM(this.Value);
        }
    
        public bool IsNotL()
        {
            return IsNotL(this.Value);
        }
    
        public bool IsNotXL()
        {
            return IsNotXL(this.Value);
        }
    
        public bool IsNotXXL()
        {
            return IsNotXXL(this.Value);
        }
    
        public void IfNotS(Action<StreamSquareSize> fn)
        {
            IfNotS(this.Value, fn);
        }
    
        public void IfNotM(Action<StreamSquareSize> fn)
        {
            IfNotM(this.Value, fn);
        }
    
        public void IfNotL(Action<StreamSquareSize> fn)
        {
            IfNotL(this.Value, fn);
        }
    
        public void IfNotXL(Action<StreamSquareSize> fn)
        {
            IfNotXL(this.Value, fn);
        }
    
        public void IfNotXXL(Action<StreamSquareSize> fn)
        {
            IfNotXXL(this.Value, fn);
        }
    
        public bool IsS()
        {
            return IsS(this.Value);
        }
    
        public bool IsM()
        {
            return IsM(this.Value);
        }
    
        public bool IsL()
        {
            return IsL(this.Value);
        }
    
        public bool IsXL()
        {
            return IsXL(this.Value);
        }
    
        public bool IsXXL()
        {
            return IsXXL(this.Value);
        }
    
        public Option<ST> AsSOption()
        {
             return AsSOption(this.Value);
        }
    
        public Option<MT> AsMOption()
        {
             return AsMOption(this.Value);
        }
    
        public Option<LT> AsLOption()
        {
             return AsLOption(this.Value);
        }
    
        public Option<XlT> AsXLOption()
        {
             return AsXLOption(this.Value);
        }
    
        public Option<XxlT> AsXXLOption()
        {
             return AsXXLOption(this.Value);
        }
    
        public void IfS(Action<ST> fn)
        {
            IfS(this.Value, fn);
        }
    
        public void IfM(Action<MT> fn)
        {
            IfM(this.Value, fn);
        }
    
        public void IfL(Action<LT> fn)
        {
            IfL(this.Value, fn);
        }
    
        public void IfXL(Action<XlT> fn)
        {
            IfXL(this.Value, fn);
        }
    
        public void IfXXL(Action<XxlT> fn)
        {
            IfXXL(this.Value, fn);
        }
    
        public static StreamSquareSize FromJson(JToken json)
        {
            return new StreamSquareSize(json.ToString());
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
            return Equals(o as StreamSquareSize);
        }
    
        public bool Equals(StreamSquareSize other)
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