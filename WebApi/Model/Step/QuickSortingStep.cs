using System.ComponentModel.DataAnnotations;

namespace WebApi.Model.Step
{
    public class QuickSortingStep
    {
        [Key]
        public int Q_StepID { get; set; }
        public int Q_Step { get; set; }
    }
}
