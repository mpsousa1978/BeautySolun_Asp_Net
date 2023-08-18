using BeautySolun.Models;
using BeautySolun.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BeautySolun.Controllers
{
    public class StatusController : Controller
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public IActionResult Index()
        {
            List<StatusModel> Status = _statusRepository.FindAll();

            return View(Status);
        }

    }
}
