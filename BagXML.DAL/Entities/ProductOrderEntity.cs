namespace BagXML.DAL.Entities
{
    public sealed class ProductOrderEntity : BaseEntity
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
