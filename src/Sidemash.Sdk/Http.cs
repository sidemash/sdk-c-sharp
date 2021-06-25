using System;
using HM = System.Net.Http.HttpMethod;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LanguageExt;
using Newtonsoft.Json.Linq;
using static LanguageExt.Prelude;


namespace Sidemash.Sdk
{
    public class Http
    {
        private static string sign(string message, string privateKey)
        {
            using (var hmac = new HMACSHA512())
            {
                return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(message))); 
            }
        }
        private static string sha256(string message)
        {
            using (var sha = SHA256Managed.Create())
            {
                return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(message))); 
            }
        }
        
        private static Map<string, string>  computeSignedHeaders(Option<string> body, Map<string, string> headers, Auth auth)
        {
            return headers
                .Add("Accept", "application/json")
                .Add("User-Agent", "Sdk C# v1.0");
        }
        
        
        public static Task<T>  doGetAsync<T>(string path, Map<string, string> headers,  string queryString, Func<JToken, T> converter, Auth auth)
        {
            return call(HM.Get, path, headers, queryString, None, converter, auth); 
        }
        
        public static Task<RestCollection<T>>  doListAsync<T>(string path, Map<string, string> headers,  string queryString, Func<JToken, T> converter, Auth auth)
        {
            return call(HM.Get, path, headers, queryString, None, json => RestCollection<T>.FromJson(json, converter), auth); 
        }

        public static Task<T> doPostAsync<T>(string path, Map<string, string> headers, string queryString, Option<string> body, Func<JToken, T> converter,Auth auth)
        {
            return call(HM.Post, path, headers, queryString, body, converter,auth); 
        }
        
        public static Task<T> doPatchAsync<T>(string path, Map<string, string> headers, string queryString, Option<string> body, Func<JToken, T> converter, Auth auth)
        {
            return call(new HM("PATCH"), path, headers, queryString, body, converter, auth); 
        }
        
        public static Task<T> doPutAsync<T>(string path, Map<string, string> headers, string queryString, Option<string> body, Func<JToken, T> converter, Auth auth)
        {
            return call(HM.Put, path, headers, queryString, body, converter, auth); 
        }

        public static Task<T> doDeleteAsync<T>(string path, Map<string, string> headers, string queryString, Option<string> body, Func<JToken, T> converter, Auth auth)
        {
            return call(HM.Delete, path, headers, queryString, body, converter,auth); 
        }

        private static async Task<T> call<T>(HM method, string path, Map<string, string> headers, string queryString, Option<string> body, Func<JToken, T> converter, Auth auth)
        {
            Map<string, string> signedHeaders = computeSignedHeaders(body, headers, auth);
            Option<string> bodyHash = body.Map(sha256); 
            SdmRequest sdmRequest = new SdmRequest(signedHeaders, method, path, queryString, bodyHash);
            Map<string, string> allHeaders =
                signedHeaders
                    .Add("X-Sdm-Nonce", sdmRequest.Nonce.ToString())
                    .Add("X-Sdm-SignedHeaders", string.Join(", ", signedHeaders.Keys))
                    .Add("X-Sdm-Signature", "SHA512 " + sign(sdmRequest.ToMessage(), auth.PrivateKey)); 
            
            
            using (var client = new HttpClient())
            {                
                client.BaseAddress = new Uri(Sdk.BaseUrl);
                foreach (var entry in allHeaders)
                {
                    client.DefaultRequestHeaders.Add(entry.Key, entry.Value); 
                }
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(method, path + queryString);
                body.IfSome(b => 
                        httpRequestMessage.Content = new StringContent(b, Encoding.UTF8, "application/json")); 
                HttpResponseMessage response = await client.SendAsync(httpRequestMessage);
                var json = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(json); // TODO Throw HttpCallException 
                }
                response.EnsureSuccessStatusCode();
                return converter(JToken.Parse(json));
            }
        }
    }
}