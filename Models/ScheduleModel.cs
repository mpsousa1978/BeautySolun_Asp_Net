using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySolun.Models
{
    public class ScheduleModel
    {
        [Key]
        public int Id_schedule { get; set; }

        [Required(ErrorMessage = "Choose Professional")]
        public int Id_professional { get; set; }

        [ForeignKey("Id_professional")]
        public virtual ProfessionalModel? Professional { get; set; }

        [Required(ErrorMessage = "Choose Date")]
        public DateTime Date_schedule { get; set; }

        [Required(ErrorMessage = "Forgot Time")]
        public  int Id_time { get; set; }
        [ForeignKey("Id_time")]
        public virtual TimeModel? time { get; set;}

        public int Id_status { get;set; }
        [ForeignKey("Id_status")]
        public virtual StatusModel? Status { get; set;}
        [Required(ErrorMessage = "Client Name")]
        public string Client_name { get; set; }
        [Required(ErrorMessage = "Client Phone")]
        public string Client_phone { get; set; }
        public double Total_price { get; set; }




    }
}
