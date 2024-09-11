using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Models
{
    public class Category
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("name_category")]
        public string NameCategory { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("state")]
        public bool State { get; set; }

    }

   
}
