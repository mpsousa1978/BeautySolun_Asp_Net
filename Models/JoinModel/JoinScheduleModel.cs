
namespace BeautySolun.Models.JoinModel
{
    public class JoinScheduleModel
    {
        public ScheduleModel ScheduleJoinModel { get; set; }
        public ProfessionalModel ProfessionalJoinModel { get; set; }
        public StatusModel StatusJoinModel { get; set; }

        public TimeModel TimeJoinModel { get; set; }

        public JoinScheduleModel(ScheduleModel schedule, ProfessionalModel professional, StatusModel status, TimeModel timeJoinModel)
        {
            ScheduleJoinModel = schedule;
            ProfessionalJoinModel = professional;
            StatusJoinModel = status;
            TimeJoinModel = timeJoinModel;
        }
    }
}

