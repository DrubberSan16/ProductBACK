using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Models
{
    [Table("product_favorite_user")]
    public class ProductFavoriteUser
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("id_product")]
        public long IdProduct { get; set; }
        [Column("uuid")]
        public string Uuid { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("total")]
        public decimal Total { get; set; }

    }
}
