using System;
using LanguageExt;
using HM = System.Net.Http.HttpMethod;

namespace Sidemash.Sdk
{
    public class SdmRequest
    {
        public SdmRequest(Map<string, string> signedHeaders,
                       HM method,
                       string path,
                       Option<string> queryString,
                       Option<string> bodyHash)
        {
            SignedHeaders = signedHeaders;
            Method = method;
            Path = path;
            Nonce = CurrentTimeMillis();
            QueryString = queryString;
            BodyHash = bodyHash;
        }

        public long Nonce { get; }
        public HM Method { get; }
        public string Path { get; }
        Option<string> QueryString { get; }
        public Map<string, string> SignedHeaders { get; }
        Option<string> BodyHash { get; }


        public string ToMessage(){
            return Nonce +
                    string.Join("", SignedHeaders.Pairs.Map((key, value) => key  + ":" + value)) +
                    Method +
                    Path +
                    QueryString.IfNone("") +
                    BodyHash.IfNone("");
        }

        private static long CurrentTimeMillis()
        {
            DateTime now = DateTime.UtcNow;
            return Convert.ToInt64((now - epoch).TotalMilliseconds);
        }
        
        private static DateTime epoch =
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    }
}