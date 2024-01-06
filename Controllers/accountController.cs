using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common.Exceptions;
using static finanza_backend_net.Models.dto.accountDto;
using finanza_backend_net.Services;
using finanza_backend_net.Models.dto;

namespace finanza_backend_net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class accountController : ControllerBase
    {
        private readonly IaccountService _service;
        public accountController(IaccountService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IActionResult getAccount([FromQuery] accountDto param)
        {
            try
            {
                var data = _service.accountList(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error= RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> postAccount([FromBody] saveAccount obj)
        {
            try
            {
                await _service.createAccount(obj);
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