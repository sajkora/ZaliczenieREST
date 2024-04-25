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

            if (_context.Pictures.Count() == 0)
            {
                _context.Pictures.Add(new Picture { Name = "Picture 1", Link="www.pic.com" });
                _context.SaveChanges();
            }
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
        public ActionResult<Picture> PostPicture(Picture picture)
        {
            _context.Pictures.Add(picture);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPicture), new { id = picture.Id }, picture);
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
