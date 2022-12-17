using Microsoft.Build.Framework;
namespace Test
{
    public class Job
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
