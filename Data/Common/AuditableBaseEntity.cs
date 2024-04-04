namespace api.techunsolved.com.Data.Common
{
    public class AuditableBaseEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
