using PedidosEBD.Domain.Core.Commands;

namespace Pedidos.Domain.Commands
{
    public abstract class CargoCommand : Command
    {
        public int Id { get; protected set; }
        public string Descricao { get; protected set; }
    }
}
