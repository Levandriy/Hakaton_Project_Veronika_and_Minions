using Microsoft.Build.Framework;
namespace Test.Models
{
    public class Catalogs
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
