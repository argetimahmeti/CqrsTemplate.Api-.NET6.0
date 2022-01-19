namespace CqrsTemplate.Data.Data.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateModified { get; set; }
    }
}
