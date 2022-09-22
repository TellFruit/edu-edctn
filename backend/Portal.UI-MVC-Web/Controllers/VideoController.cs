using Microsoft.AspNetCore.Mvc;

namespace Portal.UI_MVC_Web.Controllers
{
    [Authorize]
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await GetVideoIndexModel());
        }

        public async Task<IActionResult> AddOrEdit(int? id)
        {
             VideoDTO video;

            if (id == null)
            {
                video = new VideoDTO();
            }
            else
            {
                video = await _videoService.GetById(id.Value);
            }

            return View(video);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(VideoDTO video)
        {
            if (!ModelState.IsValid)
            {
                return View(video);
            }

            if (video.Id.Equals(default))
            {
                await _videoService.Create(video);
            }
            else
            {
                await _videoService.Update(video);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _videoService.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return PartialView("_VideoPartial", await GetVideoIndexModel());
        }

        private async Task<VideoIndexModel> GetVideoIndexModel()
        {
            var articles = await _videoService.GetAll();

            return new VideoIndexModel(articles);
        }
    }
}
