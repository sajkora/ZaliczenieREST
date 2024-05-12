using Microsoft.AspNetCore.Mvc.RazorPages;
using ZaliczenieApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ZaliczenieApi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PictureContext _context;

        public IndexModel(PictureContext context)
        {
            _context = context;
        }

        public List<Picture> Images { get; set; }

        public void OnGet()
        {
            Images = _context.Pictures.ToList();

            ViewData["ImageData"] = Images.Select(image => $"data:image/jpeg;base64,{Convert.ToBase64String(image.ImageData)}").ToList();
            ViewData["ImageNames"] = Images.Select(image => image.Name).ToList();
        }
    }
}