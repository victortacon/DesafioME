using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesafioME.Webapi.Models
{
    public class Item
    {
        public Item()
        {
            idItem = Guid.NewGuid();
        }

        [Key,JsonIgnore]
        public Guid idItem { get; set; }
        [JsonIgnore]
        public virtual Pedido Pedido { get; set; }
        [JsonIgnore]
        public string pedidoId { get; set; }
        public string descricao { get; set; }
        public decimal precoUnitario { get; set; }
        public decimal qtd { get; set; }


    }
}
