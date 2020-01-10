using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_bootcamp_b1_mert.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product> data = new List<Product>();

        [HttpGet("Get")]
        public IActionResult Get(string name = null)
        {
            if (name != null) { return Ok(data.Where(x => x.Name == name)); }

            return Ok(data);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] Product model)
        {
            model.Id = Guid.NewGuid();
            model.CreatedAt = DateTime.UtcNow;

            data.Add(model);

            return Ok($"{model.Name} eklendi");
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody]Product model)
        {
            if (model.Id == null)
                return BadRequest("id alanı boş geçilemez");

            var rec = data.Where(x => x.Id == model.Id).FirstOrDefault();
            if (rec == null)
                return BadRequest($"{model.Id} 'e ait kayıt bulunamadı");

            rec.Name = model.Name;
            rec.Price = model.Price;
            rec.Desc = model.Desc;

            return Ok($"{model.Id} 'e ait kayıt güncellendi");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([BindRequired]Guid id)
        {
            var rec = data.Where(x => x.Id == id).FirstOrDefault();
            if (rec == null)
                return BadRequest($"{id} 'e ait kayıt bulunamadı");

            data.Remove(rec);
            return Ok($"{rec.Name} silindi");
        }



    }
}
