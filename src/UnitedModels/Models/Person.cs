using System;

namespace UnitedModels.Models
{
    public class Person
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; } = "";
        
        public virtual DateTime? Timestamp { get; set; }
        
        public Address? Address { get; set; }
    }
}