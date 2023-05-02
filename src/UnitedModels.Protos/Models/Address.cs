namespace UnitedModels.Protos.Models
{
    public class Address : UnitedModels.Models.Address
    {
        public Address(Data.Address? address = null)
        {
            Message = address ?? new Data.Address();
        }
        
        public Data.Address Message { get; }

        public override long Id
        {
            get => Message.Id;
            set => Message.Id = value;
        }
        
        public override string Data
        {
            get => Message.Data;
            set => Message.Data = value;
        }
        
        public override int? LineIndex
        {
            get => Message.HasLineIndex ? Message.LineIndex : null;
            set
            {
                if (value.HasValue)
                {
                    Message.LineIndex = value.Value;
                }
                else
                {
                    Message.ClearLineIndex();
                }
            }
        }
    }
}