
using BeautySolun.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautySolun.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) :base( option ) { }

        public DbSet<StatusModel> bt_status { get; set; }

        public DbSet<TimeModel> bt_time { get; set; }

        public DbSet<ProfessionalModel> bt_professional { get; set; }

        public DbSet<ServiceModel> bt_service { get; set; }

        public DbSet<ScheduleModel> bt_schedule { get; set; }

        //public DbSet<scheduleServiceModel> bt_schedule_servicel { get; set; }

    }
}
//add-migration CriacaoTableUser -Context DataContext
//Update-database -context DataContext