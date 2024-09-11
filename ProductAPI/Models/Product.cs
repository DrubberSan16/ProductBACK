using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Models
{
    public class Product
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("name_product")]
        public string NameProduct { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("prec_unit")]
        public decimal PrecUnit { get; set; }
        [Column("state")]
        public bool State { get; set; }
        [Column("url_product")]
        public string UrlProduct { get; set; }

        [Column("id_category")]
        public long IdCategory { get; set; }
    }

}
