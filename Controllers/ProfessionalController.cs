using BeautySolun.Models.JoinModel;
using BeautySolun.Models;
using Microsoft.AspNetCore.Mvc;
using BeautySolun.Repository;

namespace BeautySolun.Controllers
{
    public class ProfessionalController : Controller
    {
        private readonly IProfessionalRepository _professionalRepository;
        private readonly IStatusRepository _statusRepository;

        public ProfessionalController (IProfessionalRepository professionalRepository, IStatusRepository statusRepository)
        {
            _professionalRepository = professionalRepository;
            _statusRepository = statusRepository;
        }

        public IActionResult Index()
        {
            List<ProfessionalModel> professional = _professionalRepository.FindAll(0);
            List<StatusModel> status = _statusRepository.FindAll();

            var ProfessionalView = from p in professional
                                   join st in status on p.Id_status equals st.Id_status into St2
                                   from st in St2.DefaultIfEmpty()
                                   select new JoinProfessionalStatusModel { professionalJoinModel = p, statusJoinModel = st };
            return View(ProfessionalView);
        }
        public IActionResult AddProfessional()
        {

            ViewBag.listofStatus = _statusRepository.GetStatusList();

            return View();
        }

        [HttpPost]
        public IActionResult AddProfessional(ProfessionalModel professionalModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _professionalRepository.AddProfessional(professionalModel);
                    TempData["MessageSucccess"] = "Professional included";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.listofStatus = _statusRepository.GetStatusList();
                    return View("AddProfessional", professionalModel);
                }
            }
            catch (Exception ex)
            {
                TempData["MensageError"] = $"Error add Service: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult EditProfessional(int id)
        {

            ViewBag.listofStatus = _statusRepository.GetStatusList();
            ProfessionalModel professionalModel = _professionalRepository.FindById(id);
            return View(professionalModel);
        }

        [HttpPost]
        public IActionResult EditProfessional(ProfessionalModel professionalModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _professionalRepository.UpdateProfessional(professionalModel);
                    TempData["MessageSuccess"] = $"Service Professional";
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.listofStatus = _statusRepository.GetStatusList();
                    return View("EditProfessional", professionalModel);
                }
            }
            catch (Exception ex)
            {
                TempData["MensageError"] = $"Error Update Service: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        //public IActionResult getTimeProfessional(int id_professional, DateTime dateTime)

        [HttpGet]
        public IActionResult getTimeProfessional(int id_professional, string dateTime)
        {
            List<TimeModel> availableTimes = _professionalRepository.GetAvailableTimes(id_professional, dateTime);
            return Json(availableTimes);
        }

    }
}
