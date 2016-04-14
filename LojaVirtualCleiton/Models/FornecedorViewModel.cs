using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaVirtualCleiton.Models
{
    public class FornecedorViewModel
    {
        public Guid? Id { get; set; }

        public string Nome { get; set; }

        public string Endereço { get; set; }

        public string Cidade { get; set; }

    }
} 