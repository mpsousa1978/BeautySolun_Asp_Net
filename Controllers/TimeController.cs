using BeautySolun.Models;
using BeautySolun.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BeautySolun.Controllers
{
    public class TimeController : Controller
    {
        private readonly ITimeRepository _timeRepository;

        public TimeController(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }
        public IActionResult Index()
        {
            List<TimeModel> timeLista = _timeRepository.FindAll();
            return View(timeLista);
        }
    }
}
