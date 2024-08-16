namespace BagXML.DAL.Entities
{
    public sealed class OrderEntity : BaseEntity
    {
        public int No { get; set; }
        public string Reg_Date { get; set; } = string.Empty;
        public double Sum { get; set; }
        public ICollection<ProductEntity> Products { get; set; } = null!;
        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!;
    }
}
