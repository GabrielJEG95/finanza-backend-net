using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions;
using finanza_backend_net.Models.dto;
using finanza_backend_net.Services;
using Microsoft.AspNetCore.Mvc;
using static finanza_backend_net.Models.dto.userInformationDto;

namespace finanza_backend_net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class userInformationController : ControllerBase
    {
        private readonly IuserInformationService _service;
        public userInformationController(IuserInformationService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IActionResult getUserInfo([FromQuery]userInformationDto param)
        {
            try
            {
                var data = _service.userInfoList(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error= RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> postUserInfo(saveUserInfo obj)
        {
            try
            {
                await _service.userInfoSave(obj);
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