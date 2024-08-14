namespace BagXML.DAL.Entities
{
    public sealed class User : BaseEntity
    {
        public string FIO { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
