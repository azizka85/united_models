namespace UnitedModels.Models
{
    public class Address
    {
        public virtual long Id { get; set; }

        public virtual string Data { get; set; } = "";
        
        public virtual int? LineIndex { get; set; }
    }
}