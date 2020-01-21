using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using net_core_bootcamp_b1_mert.DTOs;
using net_core_bootcamp_b1_mert.Helpers;
using net_core_bootcamp_b1_mert.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Add([FromBody]HWEventAddDto model)
        {
            var result = await _hweventservice.Add(model);

            if (result.Message != ApiResultMessages.Ok)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(IList<HWEventGetDto>), 200)]
        public async Task<IActionResult> Get()
        {
            var result = await _hweventservice.Get();

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]HWEventUpdateDto model)
        {
            var result = await _hweventservice.Update(model);

            if (result.Message != ApiResultMessages.Ok)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([BindRequired]Guid id)
        {
            var result = await _hweventservice.Delete(id);

            if (result.Message != ApiResultMessages.Ok)
                return BadRequest(result);

            return Ok(result);
        }
    }
}