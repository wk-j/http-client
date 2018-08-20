
using System.Net.Http;

var client = new HttpClient();
Console.WriteLine("Start connection ...");
for (int i = 0; i < 10; i++) {
    var result = await client.GetAsync("http://aspnetmonsters.com");
    Console.WriteLine(result.StatusCode);
}