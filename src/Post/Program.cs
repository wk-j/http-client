using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Post {
    class MyService {
        private IHttpClientFactory factory;
        public MyService(IHttpClientFactory factory) {
            this.factory = factory;
        }

        public async Task Post() {
            var client = factory.CreateClient();
            await client.PostAsync("http://192.168.0.20:1000", new StringContent("aaa"));
        }
    }
    class Program {
        static async Task Main(string[] args) {
            var collection = new ServiceCollection();
            collection.AddHttpClient();
            collection.AddSingleton<MyService>();

            var provider = collection.BuildServiceProvider();
            var service = provider.GetService<MyService>();

            try {
                await service.Post();
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }
    }
}
