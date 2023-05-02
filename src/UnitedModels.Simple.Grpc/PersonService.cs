using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using UnitedModels.Models;
using UnitedModels.Protos.Person;

namespace UnitedModels.Simple.Grpc
{
    public class PersonService : IPersonService
    {
        private readonly Protos.Person.PersonService.PersonServiceClient _client;

        public PersonService(string serviceUri)
        {
            var channel = GrpcChannel.ForAddress(serviceUri);

            _client = new Protos.Person.PersonService.PersonServiceClient(channel);
        }
        
        public async Task<Person> GetAsync(long id, CancellationToken cancellationToken)
        {
            var request = new GetRequest
            {
                Id = id
            };

            return new Protos.Models.Person(
                await _client.GetAsync(request, cancellationToken: cancellationToken));
        }

        public async Task<List<Person>> ListAsync(CancellationToken cancellationToken)
        {
            return (await _client.ListAsync(new Empty(), cancellationToken: cancellationToken))
                .Data
                .Select(item => new Protos.Models.Person(item) as Person)
                .ToList();
        }
    }
}