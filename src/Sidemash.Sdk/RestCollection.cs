using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LanguageExt;

namespace Sidemash.Sdk
{
    public class RestCollection<T> : IEquatable<RestCollection<T>> {
        public string Url { get; }
        public Pagination Pagination { get; }
        public List<T> Items { get; }
    
        public static readonly string Type = "RestCollection";
    
        public RestCollection(string url, Pagination pagination, List<T> items) {
            Url = url;
            Pagination = pagination;
            Items = items;
        }
    
        public string GetType() { return Type; } 
    
        public override bool Equals(object o)
        {
            return Equals(o as RestCollection<T>);
        }
    
        public bool Equals(RestCollection<T> other)
        {
            return other != null &&
                   Url.Equals(other.Url) &&
                   Pagination.Equals(other.Pagination) &&
                   Items.Equals(other.Items);
        }
    
        public override int GetHashCode()
        {
            return (Url, Pagination, Items).GetHashCode();
        }
        
        public static RestCollection<T>  FromJson(JToken json, Func<JToken, T> converter)
        {
            return new RestCollection<T>(
                json["url"].ToString(),
                Pagination.FromJson(json["pagination"]), 
                json["items"].Children().Select(converter).ToList()
            ); 
        }
    
        public override string ToString() => 
            "RestCollection{Url=" + Url +
                           ", Pagination=" + Pagination +
                           ", Items=" + Items + '}';
    }
}