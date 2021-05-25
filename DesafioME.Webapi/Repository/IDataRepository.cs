using DesafioME.Webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioME.Webapi.Repository
{
    public interface IDataRepository
    {
        Task<IEnumerable<Pedido>> GetPedidos();
        Task<Pedido> GetPedido(string Id);
        Task<Pedido> CreatePedido(Pedido pedido);
        Task UpdatePedido(Pedido pedido);
        Task DeletePedido(string Id);
        Task UpdateStatusPedido(StatusPedidoPost statusPedido);
        Task<IEnumerable<StatusPedido>> GetStatusPedido(string PedidoId);
    }
}
