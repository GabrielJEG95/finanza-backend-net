using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions;
using finanza_backend_net.Models.dto;
using finanza_backend_net.Services;
using Microsoft.AspNetCore.Mvc;
using static finanza_backend_net.Models.dto.BankDto;

namespace finanza_backend_net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class bankController : ControllerBase
    {
        private readonly IbankService _service;
        public bankController(IbankService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IActionResult getBank([FromQuery]BankDto param)
        {
            try
            {
                var data = _service.bankList(param);
                return Ok(data);
            }
            catch (System.Exception ex) 
            {
                var error= RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> postBank([FromBody] saveBank obj)
        {
            try
            {
                await _service.craeteBank(obj);
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