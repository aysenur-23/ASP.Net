using bookDemo.Models;

namespace bookDemo.Controllers.Data
{
    public static class ApplicationContext
    {
        public static List<Book> Books { get; set; }
        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                 new() { Id = 1, Title = "Uzak Yol", Price = 250 },
                 new() { Id = 2, Title = "Araba Sevdası", Price = 150 },
                 new() { Id = 3, Title = "Sergüzeşt", Price = 185 },
            };
           
        }
    }
}
