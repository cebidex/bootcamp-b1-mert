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
    public class HWEventController : ControllerBase
    {
        private readonly IHWEventService _hweventservice;
        public HWEventController(IHWEventService hweventservice)
        {
            _hweventservice = hweventservice;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody]HWEventAddDto model)
        {
            var _result = _hweventservice.Add(model);

            return Ok(_result);

        }


        [HttpGet("Get")]
        [ProducesResponseType(typeof(IList<HWEventGetDto>), 200)]
        public IActionResult Get()
        {
            var _result = _hweventservice.Get();

            return Ok(_result);

        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody]HWEventUpdateDto model)
        {
            var _result = _hweventservice.Update(model);

            return Ok(_result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([BindRequired]Guid id)
        {
            var _result = _hweventservice.Delete(id);

            return Ok(_result);
        }

    }
}
