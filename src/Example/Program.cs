using System;
using System.Threading.Tasks;
using static LanguageExt.Prelude;
using Sidemash.Sdk;

namespace Example
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //Auth auth = new Auth(token: "1234", privateKey: "****");
            Auth auth = new Auth(token: "1234", secretKey: "****");
            Client client = new Client(auth);
            //Task<Domain> createDomain = client.Domain.Create(new CreateDomainForm("example69990.com", DomainPurpose.Play, Some("My example domain name"), None)); 
            Task<StreamSquare> task = 
                client.StreamSquare.Create(
                    new CreateStreamSquareForm(
                        size: StreamSquareSize.L, 
                        isElastic: true,
                        hook: new Hook.HttpCall(method: HttpMethod.GET, url: "http://localhost/"), 
                        description: Some("My example Instance"),
                        foreignData: None, 
                        playDomainName: None, 
                        publishDomainName: None)
                    ); 
            Console.WriteLine(task.Result);
        }
    }
}
