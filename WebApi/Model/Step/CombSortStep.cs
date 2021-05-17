using System.ComponentModel.DataAnnotations;

namespace WebApi.Model.Step
{
    public class CombSortStep
    {
        [Key]
        public int C_StepID { get; set; }
        public int C_Step { get; set; }
    }
}
