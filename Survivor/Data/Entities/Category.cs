namespace Survivor.Data.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; } = "";


        public List<Competitors> Competitors { get; set; }
    }
}
