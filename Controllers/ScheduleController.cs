using BeautySolun.Models;
using BeautySolun.Models.JoinModel;
using BeautySolun.Repository;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeautySolun.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IProfessionalRepository _professionalRepository; 
        private readonly ITimeRepository _timeRepository;

        public ScheduleController(IScheduleRepository scheduleRepository, 
                                    IStatusRepository statusRepository, 
                                    IProfessionalRepository professionalRepository,
                                    ITimeRepository timeRepository)
        {
            _scheduleRepository = scheduleRepository;
            _statusRepository = statusRepository;
            _professionalRepository = professionalRepository;
            _timeRepository = timeRepository;
            
        }

        public IActionResult Index()
        {
            List<StatusModel> statusModel = _statusRepository.FindAll();
            List<ProfessionalModel> professionalModel = _professionalRepository.FindAll(0);
            List<ScheduleModel> scheduleModel = _scheduleRepository.FindAll();
            List<TimeModel> timeModel = _timeRepository.FindAll();

            var joinTables = from s in scheduleModel
                                     join p in professionalModel on s.Id_professional equals p.Id_professional into St1
                                     from p in St1.DefaultIfEmpty()
                                     join st in statusModel on s.Id_status equals st.Id_status into St2
                                     from st in St2.DefaultIfEmpty()
                                     join t in timeModel on s.Id_time equals t.Id_time into St3
                                     from t in St3.DefaultIfEmpty()
                                     select new JoinScheduleModel( s,p, st,t);
            return View(joinTables);
        }

        public IActionResult AddSchedule()
        {
            ViewBag.listOfProfessional = _professionalRepository.GetProfessionalActiveList();
            return View();
        }
        [HttpPost]
        public IActionResult AddSchedule(ScheduleModel scheduleModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _scheduleRepository.AddSchedue(scheduleModel);
                    TempData["MessageSucccess"] = "Schedule included";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.listOfProfessional = _professionalRepository.GetProfessionalActiveList();
                    return View("AddSchedule", scheduleModel);
                }
            }
            catch (Exception ex)
            {
                TempData["MensageError"] = $"Error add Service: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult EditSchedule(int id)
        {
            ViewBag.listofStatus = _statusRepository.GetStatusList();
            ViewBag.listofProfessional = _professionalRepository.GetProfessionalActiveList();
            ScheduleModel schedule = _scheduleRepository.FindById(id);
            return View(schedule);
        }

        [HttpPost]
        public IActionResult UpdateSchedule(ScheduleModel scheduleModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _scheduleRepository.UpdateSchedue(scheduleModel);
                    TempData["MessageSuccess"] = $"Service Professional";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.listofStatus = _statusRepository.GetStatusList();
                    ViewBag.listofProfessional = _professionalRepository.GetProfessionalActiveList();
                    return View("EditSchedule", scheduleModel);
                }
            }
            catch (Exception ex)
            {
                TempData["MensageError"] = $"Error Update Schedule: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
