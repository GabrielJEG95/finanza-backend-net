using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions;
using finanza_backend_net.Models.dto;
using finanza_backend_net.Services;
using Microsoft.AspNetCore.Mvc;
using static finanza_backend_net.Models.dto.accountModeDto;

namespace finanza_backend_net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class accountModeController : ControllerBase
    {
        private IaccountModeService _service;
        public accountModeController(IaccountModeService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IActionResult getAccountMode([FromQuery] accountModeDto param)
        {
            try
            {
                var data = _service.accountModeList(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error= RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> postAccountMode ([FromBody] saveAccountMode obj)
        {
            try
            {
                await _service.createAccountMode(obj);
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