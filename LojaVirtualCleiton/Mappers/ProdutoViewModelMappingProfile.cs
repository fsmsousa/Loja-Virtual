using AutoMapper;
using LojaVirtualCleiton.Models;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaVirtualCleiton.Mappers
{
    public class ProdutoViewModelMappingProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Produto, ProdutoListaViewModel>()
            .ForMember (dest=> dest.Categoria, opt => opt.MapFrom(src => src.Categoria.Nome));

            Mapper.CreateMap<Produto, ProdutoViewModel>();

            Mapper.CreateMap<ProdutoViewModel, Produto>();
                
        }
    }
}