using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Performance {
    class Program {
        static async Task Main(string[] args) {
            Console.WriteLine("Start connection ...");
            for (int i = 0; i < 10; i++) {
                using (var client = new HttpClient()) {
                    var result = await client.GetAsync("https://google.com");
                    Console.WriteLine(result.StatusCode);
                }
            }

        }
    }
}
