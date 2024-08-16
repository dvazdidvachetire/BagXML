namespace BagXML.DAL.Entities
{
    /// <summary>представляет сущность продукт-заказ</summary>
    public sealed class ProductOrderEntity : BaseEntity
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
