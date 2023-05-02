using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using UnitedModels.Protos.Models;
using UnitedModels.Protos.Person;
using PersonGrpcServiceBase = UnitedModels.Protos.Person.PersonService.PersonServiceBase;

namespace UnitedModels.Simple.Grpc.Service.GrpcServices
{
    public class PersonGrpcService : PersonGrpcServiceBase
    {
        private readonly Dictionary<long, Person> _data;

        private readonly Person _defaultPerson;

        public PersonGrpcService()
        {
            _data = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    Name = "Person #1",
                    Timestamp = new DateTime(2023, 4,30, 12, 9, 0, DateTimeKind.Utc),
                    Address = new Address{
                        Id = 1,
                        Data = "Almaty, Kazakhstan",
                        LineIndex = 23
                    }
                },
                new Person
                {
                    Id = 2,
                    Name = "Person #2",
                    Timestamp = new DateTime(2023, 4,30, 12, 12, 0, DateTimeKind.Utc),
                    Address = new Address{
                        Id = 2,
                        Data = "Astana, Kazakhstan",
                        LineIndex = 13
                    }
                },
                new Person
                {
                    Id = 3,
                    Name = "Person #3",
                    Timestamp = new DateTime(2023, 4,30, 12, 13, 0, DateTimeKind.Utc),
                    Address = new Address{
                        Id = 3,
                        Data = "Shymkent, Kazakhstan",
                        LineIndex = 3
                    }
                }
            }.ToDictionary(item => item.Id);

            _defaultPerson = new Person
            {
                Id = 4,
                Name = "Person #4"
            };
        }

        public override Task<Protos.Data.Person> Get(GetRequest request, ServerCallContext __)
        {
            return Task.FromResult(
                Get(request.Id));
        }

        public override Task<ListResponse> List(Empty _, ServerCallContext __)
        {
            return Task.FromResult(
                List());
        }

        private Protos.Data.Person Get(long id)
        {
            var person = _data.TryGetValue(id, out var value)
                ? value
                : _defaultPerson;

            return person.Message;
        }

        private ListResponse List()
        {
            var response = new ListResponse();

            for (int i = 0; i < 1000; i++)
            {
                response.Data.Add(
                    Get(i % 4 + 1));
            }
            
            return response;
        }
    }
}