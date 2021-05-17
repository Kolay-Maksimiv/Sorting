using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class DataQuickSorting
    {
        [Key]
        public int quickSortingID { get; set; }
        public double quickSortingTime { get; set; }
    }
}
