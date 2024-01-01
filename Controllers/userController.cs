using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions;
using finanza_backend_net.Models.dto;
using finanza_backend_net.Services;
using Microsoft.AspNetCore.Mvc;
using static finanza_backend_net.Models.dto.userDto;

namespace finanza_backend_net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class userController : ControllerBase
    {
        private readonly IuserService _service;
        public userController(IuserService iuserService)
        {
            this._service = iuserService;
        }      

        [HttpGet]
        public IActionResult getUsers([FromQuery]userDto param)  
        {
            try
            {
                var data = _service.userList(param);

                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error= RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> postUsers([FromBody] saveUser obj)
        {
            try
            {
                await _service.createUser(obj);
                return Ok(RespuestaModel.CreacionExitosa());
            }
            catch (System.Exception ex)
            {
                var error= RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }

        [HttpPut("{IdUser:int}")]
        public async Task<IActionResult> PutUser(int IdUser, [FromBody] UpdateUser obj)
        {
            try
            {
                await _service.updateUser(IdUser,obj);
                return Ok(RespuestaModel.ActualizacionExitosa());
            }
            catch (System.Exception ex)
            {
                var error= RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }
    }
}