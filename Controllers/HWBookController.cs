using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using net_core_bootcamp_b1_mert.DTOs;
using net_core_bootcamp_b1_mert.Services;
using System;
using System.Collections.Generic;

namespace net_core_bootcamp_b1_mert.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class HWBookController : ControllerBase
    {
        private readonly IHWBookService _hwbookservice;
        public HWBookController(IHWBookService hwbookservice)
        {
            _hwbookservice = hwbookservice;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody]HWBookAddDto model)
        {
            var _result = _hwbookservice.Add(model);

            return Ok(_result);

        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(IList<HWBookGetDto>), 200)]
        public IActionResult Get()
        {
            var _result = _hwbookservice.Get();

            return Ok(_result);

        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody]HWBookUpdateDto model)
        {
            var _result = _hwbookservice.Update(model);

            return Ok(_result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([BindRequired]Guid id)
        {
            var _result = _hwbookservice.Delete(id);

            return Ok(_result);
        }

    }
}