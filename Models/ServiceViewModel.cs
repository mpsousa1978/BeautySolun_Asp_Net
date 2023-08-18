using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ExceptionServices;

namespace BeautySolun.Models
{
    public class ServiceViewModel
    {
        [Key]
        public int Id_service { get; set; }
        public string Description { get; set; }
        public Double Price { get; set; }
        public int Id_status { get; set;}
        public int Id_status_description { get; set; }

    }
}
