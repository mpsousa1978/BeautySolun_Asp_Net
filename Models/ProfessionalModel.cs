using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySolun.Models
{
    public class ProfessionalModel
    {
        [Key]
        public int Id_professional { get; set; }

        [Required(ErrorMessage = "Name of Professional")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail of Professional")]
        [EmailAddress(ErrorMessage = "Invalid e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Status of Professional")]
        public int Id_status { get; set; }
        [ForeignKey("Id_status")]
        public virtual StatusModel? Status { get; set; }


    }
}
