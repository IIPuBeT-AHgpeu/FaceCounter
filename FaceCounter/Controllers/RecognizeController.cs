using FaceCounter.Models;
using FaceCounter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FaceCounter.Controllers
{
    [ApiController]
    [Route("recognize")]
    public class RecognizeController : ControllerBase
    {
        private Recognizer _recognizer;
        private IRepository<Recognize> _rep;

        public RecognizeController(Recognizer recognizer, IRepository<Recognize> rep)
        {
            _recognizer = recognizer;
            _rep = rep;
        }

        [HttpPost]
        public IActionResult Recognize(IFormFile image)
        {
            if (image == null) return BadRequest();

            try
            {
                int count = 0;
                Recognize rec = new Recognize();

                using (var ms = new MemoryStream())
                {
                    image.CopyTo(ms);

                    byte[] bytes = ms.ToArray();

                    rec.Image = bytes;

                    count = _recognizer.GetObjectsCount(bytes);
                    rec.Result = count;
                }

                var create = _rep.Create(rec);

                if (create) return Ok(count);
                else return StatusCode(500, "¬нутренн€€ ошибка сервера");
            }
            catch (Exception e)
            {
                return StatusCode(500, "¬нутренн€€ ошибка сервера");
            }
        }
    }
}
