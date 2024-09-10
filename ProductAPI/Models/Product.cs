namespace ProductAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; }
        public decimal PrecUnit { get; set; }
        public bool State { get; set; }
        public string UrlProduct { get; set; }

        public Category Category { get; set; }
        public ICollection<ProductFavoriteUser> ProductFavoriteUsers { get; set; }
    }

}
