using BeautySolun.Data;
using BeautySolun.Models;
using BeautySolun.Models.JoinModel;
using BeautySolun.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeautySolun.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IStatusRepository  _statusRepository;

        public ServiceController (IServiceRepository serviceRepository, IStatusRepository statusRepository )
        {
            _serviceRepository = serviceRepository;
            _statusRepository = statusRepository;  
        }


        public IActionResult Index()
        {
            List<ServiceModel> service= _serviceRepository.FindAll();
            List<StatusModel>   status = _statusRepository.FindAll();

            var serviceView = from s in service
                                    join st in status on s.Id_status equals st.Id_status into St2
                                    from st in St2.DefaultIfEmpty()
                                    select new JoinServiceStatusModel { serviceViewModel = s, statusViewModel = st };

            return View(serviceView);
            //https://www.youtube.com/watch?v=pChkbx9BFVA
            //https://www.youtube.com/watch?v=lco825FU73Q
            //http://www.codingfusion.com/Post/How-to-Join-tables-and-return-result-into-view-usi

        }

        public IActionResult AddService()
        {

            ViewBag.listofStatus = _statusRepository.GetStatusList();

            return View();
        }

        [HttpPost]
        public IActionResult AddService(ServiceModel serviceModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceRepository.AddService(serviceModel);
                    TempData["MessageSucccess"] = "Service included";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.listofStatus = _statusRepository.GetStatusList();
                    return View("AddService", serviceModel);
                }
            }
            catch (Exception ex)
            {
                TempData["MensageError"] = $"Error add Service: {ex.Message}";
                return RedirectToAction("Index");
            }
        }


        public IActionResult EditService(int id)
        {

            ServiceModel service = _serviceRepository.FindById(id);
            ViewBag.listofStatus = _statusRepository.GetStatusList();
            return View(service);
        }

        [HttpPost]
        public IActionResult UpdateService(ServiceModel serviceModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceRepository.UpdateService(serviceModel);
                    TempData["MessageSuccess"] = $"Service updated";
                    return RedirectToAction("Index");
                
                }
                else
                {
                    ViewBag.listofStatus = _statusRepository.GetStatusList();
                    return View("EditService",serviceModel);
                }
            }
            catch(Exception ex)
            {
                TempData["MensageError"] = $"Error Update Service: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
