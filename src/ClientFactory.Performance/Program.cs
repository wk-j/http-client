using System;
using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.DependencyInjection;

namespace ClientFactory.Performance {
    class Program {
        static void Main(string[] args) {
            BenchmarkRunner.Run<MyService>();
        }
    }

    public class Config : ManualConfig {
        public Config() {
            this.Add(
                Job.Dry.WithLaunchCount(1)
            );
        }

    }

    [Config(typeof(Config))]
    [MemoryDiagnoser]
    public class MyService {
        IHttpClientFactory factory;

        [Params(5)]
        public int Count { set; get; }

        [GlobalSetup]
        public void Setup() {
            var sc = new ServiceCollection();
            sc.AddHttpClient();
            var provider = sc.BuildServiceProvider();
            factory = provider.GetService<IHttpClientFactory>();
        }

        private async Task<int> Google(Func<HttpClient> builder, string web) {
            int all = 0;
            for (int i = 0; i < Count; i++) {
                var client = builder();
                var rs = await client.GetStringAsync(web);
                all += rs.Length;
                Console.WriteLine(rs.Length);
            }
            return all;
        }


        [Benchmark]
        public async Task<int> News() {
            return await Google(() =>
                new HttpClient(),
                "https://www.takemetour.com"
            );
        }

        [Benchmark]
        public async Task<int> Share() {
            return await Google(() =>
                factory.CreateClient(),
                "https://www.blognone.com"
            );
        }
    }
}