#! "netcoreapp2.1"

using System.Net.Http;

Console.WriteLine("Start connection ...");
for (int i = 0; i < 10; i++) {
    using (var client = new HttpClient()) {
        var result = await client.GetAsync("http://aspnetmonsters.com");
        Console.WriteLine(result.StatusCode);
    }
}