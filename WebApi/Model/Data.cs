using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class Data
    {
        [Key]
        public int TimeId { get; set; }
        public int ExecutionTime { get; set; }
    }
}
