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
    public class PedidoController : ControllerBase
    {

        private readonly IDataRepository _dataRepository;

        public PedidoController([FromServices] IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Pedido>> GetPedidos()
        {
            return await _dataRepository.GetPedidos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(string id)
        {
            return await _dataRepository.GetPedido(id);
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido([FromBody] Pedido pedido)
        {

            if(!ModelState.IsValid)
                return NotFound("Verifique o pedido! Erro na inserção!");

            try
            {
                var newPedido = await _dataRepository.CreatePedido(pedido);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult<Pedido>> PutPedido([FromBody] Pedido pedido)
        {

            if (!ModelState.IsValid)
                return NotFound("Verifique o pedido! Erro na atualização!");

            try
            {
                await _dataRepository.UpdatePedido(pedido);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePedido(string id)
        {
            try
            {
                var pedidoToDelete = await _dataRepository.GetPedido(id);

                if (pedidoToDelete == null) return NotFound("Pedido não localizado!");

                await _dataRepository.DeletePedido(pedidoToDelete.pedido);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
