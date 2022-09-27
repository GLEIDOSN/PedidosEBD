using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosEBD.Infra.Data
{
    public class PedidosEBDContext : DbContext
    {
        public PedidosEBDContext(DbContextOptions options) : base(options)
        {

        }
    }
}
