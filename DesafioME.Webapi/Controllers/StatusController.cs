using DesafioME.Webapi.Models;
using DesafioME.Webapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioME.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly IDataRepository _dataRepository;

        public StatusController([FromServices] IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpPost]
        public async Task<ActionResult<StatusPedidoPost>> PostStatusPedido([FromBody] StatusPedidoPost statusPedidoPost)
        {

            if (!ModelState.IsValid)
                return NotFound("Verifique o status! Erro na inserção!");

            try
            {
                await _dataRepository.UpdateStatusPedido(statusPedidoPost);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

        }


    }
}
