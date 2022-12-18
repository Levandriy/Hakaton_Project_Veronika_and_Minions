using Microsoft.Build.Framework;
namespace Test.Models
{
    public class Access_cons
    {
        public int Id { get; set; }
        [Required]
        public int Material_id { get; set; }
        public int? Job_id { get; set; }
        [Required]
        public int Department_id { get; set; }
    }
}
