using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions;
using finanza_backend_net.Models.dto;
using finanza_backend_net.Services;
using Microsoft.AspNetCore.Mvc;
using static finanza_backend_net.Models.dto.countryDto;

namespace finanza_backend_net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class countryController : ControllerBase
    {
        private readonly IcountryService _service;
        public countryController(IcountryService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IActionResult getCountry ([FromQuery] countryDto param)
        {
            try
            {
                var data = _service.countryList(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error= RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> postCountry ([FromForm] saveCoutry obj)
        {
            try
            {
                await _service.createCountry(obj);
                return Ok(RespuestaModel.CreacionExitosa());
            }
            catch (System.Exception ex)
            {
                var error= RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }
    }
}