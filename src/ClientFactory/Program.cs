using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ClientFactory {
    class Program {
        static async Task Main(string[] args) {

            var collection = new ServiceCollection();
            collection.AddHttpClient();
            collection.AddSingleton<MyService>();

            var provider = collection.BuildServiceProvider();
            var myService = provider.GetService(typeof(MyService)) as MyService;

            for (int i = 0; i < 10; i++) {
                var rs = await myService.GetGoogle();
                Console.WriteLine(rs.Split('\n').Length);
            }
        }
    }

    class MyService {
        IHttpClientFactory factory;
        public MyService(IHttpClientFactory factory) {
            this.factory = factory;
        }

        public async Task<string> GetGoogle() {
            var client = factory.CreateClient();
            return await client.GetStringAsync("http://aspnetmonsters.com");
        }
    }
}
