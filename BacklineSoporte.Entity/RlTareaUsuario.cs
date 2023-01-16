using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class RlTareaUsuario
    {
        public int Id { get; set; }
        public int Contador { get; set; }

        public int Usr_Id { get; set; }

        public int Tar_Id { get; set; }

        public string Nombre { get; set; }
    }
}
