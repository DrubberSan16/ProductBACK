namespace ProductAPI.Models
{
    public class ProductFavoriteUser
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public Guid Uuid { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public Product Product { get; set; }
    }
}
