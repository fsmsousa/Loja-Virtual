using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Fornecedor
    {

        public virtual Guid? Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Endereco { get; set; }

        public virtual string Cidade { get; set; }


    }
}
