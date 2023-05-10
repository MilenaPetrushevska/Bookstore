using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookstore.Controllers
{
    public class BufferedFileUploadController : Controller
    {
        readonly IBufferedFileUploadService _bufferedFileUploadService;
        public BufferedFileUploadController(IBufferedFileUploadService bufferedFileUploadService)
        {
            _bufferedFileUploadService = bufferedFileUploadService;
        }/*
        private List<SelectListItem> GetUploadedFiles()
        {
            var folderPath = "C:\\Users\\User\\Desktop\\Bookstore\\UploadedFiles\\";
            var folder = new DirectoryInfo(folderPath);
            var files = folder.GetFiles();

            var selectList = files.Select(file => new SelectListItem
            {
                Value = file.Name,
                Text = file.Name
            }).ToList();

            return selectList;
        }
        public IActionResult Create()
        {
            ViewBag.UploadedFiles = GetUploadedFiles();
            return View();
        }*/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(IFormFile file)
        {
            
            try
            {
                if (await _bufferedFileUploadService.UploadFile(file))
                {
                    ViewBag.Message = "File Upload Successful";
                }
                else
                {
                    ViewBag.Message = "File Upload Failed";
                }
            }
            catch (Exception ex)
            {
                //Log ex
                ViewBag.Message = "File Upload Failed";
            }
            return View();
        }
    }
}
