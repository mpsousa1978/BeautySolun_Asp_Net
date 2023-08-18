using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySolun.Models
{
    public class ServiceModel
    {
        [Key]
        public int Id_service { get; set; }

        [Required(ErrorMessage = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price")]
        public Double Price { get; set; }

        [Required(ErrorMessage = "Status")]
        public int Id_status { get; set;}
        [ForeignKey("Id_status")]
        public virtual StatusModel? Status { get; set; }

    }
}
