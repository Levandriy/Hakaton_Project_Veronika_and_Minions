using Microsoft.Build.Framework;
namespace Test.Models
{
    public class Catalog_cons
    {
        public int Id { get; set; }
        [Required]
        public int Catalog_id { get; set; }
        [Required]
        public int Material_id { get; set; }
    }
}
