using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaVirtualCleiton.Models
{
    public class ProdutoViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatorio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatorio.")]
        public CategoriaViewModel Categoria { get; set; }

        [Required(ErrorMessage = "Fornecedor é obrigatorio.")]
        public FornecedorViewModel Fornecedor { get; set; }

        public Guid CategoriaId { get; set; }

        public IList<CategoriaViewModel> Categorias { get; set; }
        public IList<FornecedorViewModel> Fornecedores { get; set; }
    }
} 