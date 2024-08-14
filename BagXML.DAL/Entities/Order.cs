namespace BagXML.DAL.Entities
{
    public sealed class Order : BaseEntity
    {
        public int No { get; set; }
        public DateTime Reg_Date { get; set; }
        public double Sum { get; set; }
        public ICollection<Product> Products { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
