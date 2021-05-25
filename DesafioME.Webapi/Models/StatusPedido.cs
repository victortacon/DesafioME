using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesafioME.Webapi.Models
{
    [NotMapped]
    public class StatusPedido
    {
        public StatusPedido()
        {
            idStatus = Guid.NewGuid();
        }

        [Key, JsonIgnore]
        public Guid idStatus { get; set; }
        [JsonIgnore]
        public virtual Pedido Pedido { get; set; }
       
        public string pedido { get; set; }
        public string Status { get; set; }
    }

    public class StatusPedidoRequest : StatusPedido
    {

    }
    public class StatusPedidoPost : StatusPedido
    {
        public decimal itensAprovados { get; set; }
        public decimal valorAprovado { get; set; }
    }
}
