namespace BagXML.DAL.Entities
{
    public sealed class UserEntity : BaseEntity
    {
        public string FIO { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
