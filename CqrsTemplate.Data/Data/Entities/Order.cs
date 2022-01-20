namespace CqrsTemplate.Data.Data.Entities
{
    public class Order : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Item? Item { get; set; }
        public int Quatity { get; set; }

    }
}
