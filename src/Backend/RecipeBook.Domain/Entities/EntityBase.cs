namespace RecipeBook.Domain.Entities
{
    public class EntityBase
    {
        public long Id { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
