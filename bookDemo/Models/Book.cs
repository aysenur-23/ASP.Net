namespace bookDemo.Models
{
    public class Book
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public required string Title { get; set; }
    }
}
