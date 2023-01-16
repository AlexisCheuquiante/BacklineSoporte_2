using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class UsuarioFarmacia
    {
        public int Id { get; set; }
        public int Emp_Id { get; set; }
        public string Nombre { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public int Contador { get; set; }

    }
}
