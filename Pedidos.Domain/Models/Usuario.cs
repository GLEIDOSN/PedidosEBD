using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedidos.Domain.Models
{
    public class Usuario
    {
        public int Id {get; set;}

        public string NomeUsuario {get; set;}

        public string Password {get; set;}

        public Boolean Ativo {get; set;}

    }
}