using PedidosEBD.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Domain.Events
{
    public class CargoCreatedEvent : Event
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }

        public CargoCreatedEvent(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;  
        }
    }
}
