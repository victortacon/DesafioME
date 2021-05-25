using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesafioME.Webapi.Models
{
    public class Pedido
    {

        public Pedido()
        {
           // id = Guid.NewGuid();
            Itens = new List<Item>();
        }

        [Key]
        //public Guid id { get; set; }      
        public string pedido { get; set; }
        public ICollection<Item> Itens { get; set; }
        [JsonIgnore]
        public ICollection<StatusPedidoRequest> StatusPedidos { get; set; }



    }
}
