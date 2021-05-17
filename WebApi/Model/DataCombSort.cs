using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class DataCombSort
    {
        [Key]
        public int combSortID { get; set; }
        public double combSortTime { get; set; }
    }
}
