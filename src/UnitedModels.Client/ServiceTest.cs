using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using PersonServiceHttp = UnitedModels.Http.PersonService;
using PersonServiceSimpleGrpc = UnitedModels.Simple.Grpc.PersonService;
using PersonServiceMapGrpc = UnitedModels.Map.Grpc.PersonService;

namespace UnitedModels.Client
{
    public class ServiceTest
    {
        private readonly PersonServiceHttp _serviceHttp;
        private readonly PersonServiceSimpleGrpc _serviceSimpleGrpc;
        private readonly PersonServiceMapGrpc _serviceMapGrpc;

        public ServiceTest()
        {
            _serviceHttp = new PersonServiceHttp("http://localhost:8177");
            _serviceSimpleGrpc = new PersonServiceSimpleGrpc("http://localhost:8277");
            _serviceMapGrpc = new PersonServiceMapGrpc("http://localhost:8377");
        }

        [Benchmark()]
        public async Task TestGetHttpAsync()
        {
            await _serviceHttp.GetAsync(1, CancellationToken.None);
        }
        
        [Benchmark]
        public async Task TestGetSimpleGrpcAsync()
        {
            await _serviceSimpleGrpc.GetAsync(2, CancellationToken.None);
        }
        
        [Benchmark]
        public async Task TestGetMapGrpcAsync()
        {
            await _serviceMapGrpc.GetAsync(3, CancellationToken.None);
        }

        [Benchmark]
        public async Task TestListHttpAsync()
        {
            await _serviceHttp.ListAsync(CancellationToken.None);
        }

        [Benchmark]
        public async Task TestListSimpleGrpcAsync()
        {
            await _serviceSimpleGrpc.ListAsync(CancellationToken.None);
        }

        [Benchmark]
        public async Task TestListMapGrpcAsync()
        {
            await _serviceMapGrpc.ListAsync(CancellationToken.None);
        }
    }
}