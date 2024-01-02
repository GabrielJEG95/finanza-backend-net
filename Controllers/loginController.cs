using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions;
using finanza_backend_net.Services;
using Microsoft.AspNetCore.Mvc;
using static finanza_backend_net.Models.dto.loginDto;

namespace finanza_backend_net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class loginController : ControllerBase
    {
        private readonly IloginService _service;
        public loginController(IloginService service)
        {
            this._service = service;
        }

        [HttpPost]
        public IActionResult login(loginUser obj)
        {
            try
            {
                var data = _service.login(obj);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error= RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }
    }
}