using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using UnitedModels.Protos.Models;
using UnitedModels.Protos.Person;
using Person = UnitedModels.Models.Person;

namespace UnitedModels.Map.Grpc
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

            return Get(
                await _client.GetAsync(request, cancellationToken: cancellationToken));
        }

        public async Task<List<Person>> ListAsync(CancellationToken cancellationToken)
        {
            return (await _client.ListAsync(new Empty(), cancellationToken: cancellationToken))
                .Data
                .Select(item => Get(item))
                .ToList();
        }

        public Person Get(Protos.Data.Person item)
        {
            var person = new Protos.Models.Person
            {
                Id = item.Id,
                Name = item.Name,
                Timestamp = item.Timestamp?.ToDateTime()
            };

            if (item.Address != null)
            {
                person.Address = new Address
                {
                    Id = item.Address.Id,
                    Data = item.Address.Data,
                    LineIndex = item.Address.HasLineIndex ? item.Address.LineIndex : null
                };
            }

            return person;
        }
    }
}