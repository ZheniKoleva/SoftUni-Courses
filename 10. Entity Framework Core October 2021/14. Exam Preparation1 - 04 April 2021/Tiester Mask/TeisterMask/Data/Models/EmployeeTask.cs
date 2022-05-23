namespace TeisterMask.Data.Models
{   
    using System.ComponentModel.DataAnnotations.Schema;

    public class EmployeeTask
    {        
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        [ForeignKey(nameof(Task))]
        public int TaskId { get; set; }

        public virtual Task Task { get; set; }

    }
}
