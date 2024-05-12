using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZaliczenieApi.Models;

namespace ZaliczenieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly PictureContext _context;

        public PicturesController(PictureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Picture> GetProducts()
        {
            return _context.Pictures.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Picture> GetPicture(int id)
        {
            var Product = _context.Pictures.Find(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Product;
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public ActionResult<Picture> PostPicture([FromForm] IFormFile imageFile, [FromForm] string name)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return BadRequest("No image file uploaded.");
            }

            using (var memoryStream = new MemoryStream())
            {
                imageFile.CopyTo(memoryStream);
                byte[] imageData = memoryStream.ToArray();

                var picture = new Picture
                {
                    Name = name,
                    ImageData = imageData
                };

                _context.Pictures.Add(picture);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetPicture), new { id = picture.Id }, picture);
            }
        }


        [HttpPut("{id}")]
        public IActionResult PutPicture(int id, Picture picture)
        {
            if (id != picture.Id)
            {
                return BadRequest();
            }

            _context.Pictures.Update(picture);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeletePicture(int id) 
        {
            var Picture = _context.Pictures.Find(id);
            if (Picture==null)
            {
                return NotFound();
            }
            _context.Pictures.Remove(Picture);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
