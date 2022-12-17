using Microsoft.Build.Framework;
namespace Test
{
    public class Access_cons
    {
        public int Id { get; set; }
        [Required]
        public int Material_id { get; set; }
        public int? Access_id { get; set; }
        [Required]
        public int Department_id { get; set; }
    }
}
