using Microsoft.Build.Framework;
namespace Test.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Department_id { get; set; }
    }
}
