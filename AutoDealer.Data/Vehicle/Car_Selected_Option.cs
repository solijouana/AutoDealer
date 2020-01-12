using AutoDealer.Data.BaseType;

namespace AutoDealer.Data.Vehicle
{
    public class Car_Selected_Option : BaseEntity
    {
        public int CarID { get; set; }
        public int OptionID { get; set; }   

        public virtual Car Car { get; set; }
        public virtual Option Option { get; set; }
    }
}
