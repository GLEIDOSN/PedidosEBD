using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Domain.Commands
{
    public class CreateCargoCommand : CargoCommand
    {
        public CreateCargoCommand(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
