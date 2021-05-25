using DesafioME.Webapi.Data;
using DesafioME.Webapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioME.Webapi.Repository
{
    public class DataRepository : IDataRepository
    {

        private readonly DataContext _context;

        public DataRepository([FromServices] DataContext context)
        {
            _context = context;
        }

        public async Task<Pedido> CreatePedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        public async Task DeletePedido(string Id)
        {
            var pedidoToDelete = await _context.Pedidos
                .Include(p => p.Itens)
                .Include(s => s.StatusPedidos)
                .FirstOrDefaultAsync(x => x.pedido == Id);
            _context.Pedidos.Remove(pedidoToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Pedido> GetPedido(string Id)
        {
            return await _context.Pedidos
                .Include(i => i.Itens)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.pedido == Id);
        }

        public async Task<IEnumerable<Pedido>> GetPedidos()
        {
            return await _context.Pedidos
                .Include(i => i.Itens)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<StatusPedido>> GetStatusPedido(string PedidoId)
        {
            return await _context.StatusPedidos.Where(s => s.pedido == PedidoId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdatePedido(Pedido pedido)
        {

            var itens = _context.Item.Where(i => i.pedidoId == pedido.pedido);
            _context.Item.RemoveRange(itens);
            _context.Item.AddRange(pedido.Itens);

            _context.Entry(pedido).State = EntityState.Modified;

            //_context.Pedidos
            //    .Update(pedido);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusPedido(StatusPedidoPost statusPedido)
        {
            var statusPedidos = GetStatusPedido(statusPedido.pedido).Result.ToList();

            var status = new StatusPedido { 
                idStatus = statusPedido.idStatus,
                Pedido=statusPedido.Pedido,
                pedido=statusPedido.pedido,
                Status=statusPedido.Status
            };


            if (statusPedidos.Where(s => s.Status == statusPedido.Status).Count() == 0)
                _context.StatusPedidos.Add(status);
            else
                _context.Entry(status).State = EntityState.Modified;

            await _context.SaveChangesAsync();


        }
    }
}
