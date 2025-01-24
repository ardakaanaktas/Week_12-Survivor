namespace Survivor.Data.Entities
{
    public class Competitors: BaseEntity
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
