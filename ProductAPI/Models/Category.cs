namespace ProductAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }

        public ICollection<Product> Products { get; set; }
    }

   
}
