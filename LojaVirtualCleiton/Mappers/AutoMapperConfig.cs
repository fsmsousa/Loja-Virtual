using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaVirtualCleiton.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x=>
           {
               x.AddProfile<ProdutoViewModelMappingProfile>();
               x.AddProfile<CategoriaViewModelMappingProfile>();
               x.AddProfile<FornecedorViewModelMappingProfile>();
           });
        }
    }
}