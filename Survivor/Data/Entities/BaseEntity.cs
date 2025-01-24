namespace Survivor.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool isDeleted { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            isDeleted = false;
        }

    }
}
