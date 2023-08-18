using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySolun.Models
{
    public class scheduleServiceModel
    {
        [Key]
        public int Id_schedule_service { get; set; }

        public int Id_schedule   { get; set;}
        [ForeignKey("Id_schedule")]
        public virtual ScheduleModel? schedule { get; set; }
        public int Id_service { get; set; }
        [ForeignKey("Id_service")]
        public virtual ServiceModel? service { get; set; }
    }
}
