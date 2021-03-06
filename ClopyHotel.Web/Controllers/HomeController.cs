using ClopyHotel.Application.Interfaces;
using ClopyHotel.Application.ViewModel;
using ClopyHotel.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ClopyHotel.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoomService _roomService;

        public HomeController(ILogger<HomeController> logger, IRoomService roomService)
        {
            _logger = logger;
            _roomService = roomService;
        }

        public IActionResult Index()
        {
            var model = new ListRoomViewModel()
            {
                Rooms = _roomService.GetRooms()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var newRoom = await _roomService.Create(
                  new RoomViewModel()
                  {
                      RoomName = "Deluxe 2.002",
                      RoomTypeId = 4,
                      Description = "Deluxe double suitable for family or group people more than 2"
                  }
                  );
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
