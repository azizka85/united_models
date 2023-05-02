using System;

namespace UnitedModels.Protos.Models
{
    public class Person : UnitedModels.Models.Person
    {
        private Address? _address;
        
        public Person(Data.Person? person = null)
        {
            Message = person ?? new Data.Person();

            if (Message.Address != null)
            {
                _address = new Address(Message.Address);
            }
        }
        
        public Data.Person Message { get; }
        
        public override long Id
        {
            get => Message.Id;
            set => Message.Id = value;
        }

        public override string Name
        {
            get => Message.Name;
            set => Message.Name = value;
        }

        public override DateTime? Timestamp
        {
            get => Message.Timestamp?.ToDateTime();
            set
            {
                if (value.HasValue)
                {
                    Message.Timestamp = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(value.Value);
                }
                else
                {
                    Message.Timestamp = null;
                }
            }
        }

        public new Address? Address
        {
            get => _address;
            set
            {
                Message.Address = value?.Message;

                _address = value;
            }
        }
    }
}