using AutoMapper;
using LojaVirtualCleiton.Models;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace LojaVirtualCleiton.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Lista()

        {
            var produtos = new Produtos();

            var listaProdutos = produtos.Lista();

            var lista = Mapper.Map<IList<ProdutoListaViewModel>>(listaProdutos);

            return View(lista);

        }

        public ActionResult Editar(Guid? id = null)
        {
            ProdutoViewModel viewModel;

            if (id != null)
            {
                var produtos = new Produtos();

                var produto = produtos.Por(id);

                viewModel = Mapper.Map<ProdutoViewModel>(produto);
            }
            else
            {
                viewModel = new ProdutoViewModel();
            }

            var categorias = new Categorias();

            var ListaCategorias = categorias.Lista();

            viewModel.Categorias = Mapper.Map<IList<CategoriaViewModel>>(ListaCategorias);

            return View(viewModel);
        }


        public ActionResult Apagar(Guid id)
        {
            var produtos = new Produtos();

            produtos.Apagar(id);

            return RedirectToAction("Lista");

        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ProdutoViewModel viewModel)
        {
                if (ModelState.IsValid)
            {
                var produtos = new Produtos();

                var produto = Mapper.Map<Produto>(viewModel);

                produtos.Salvar(produto);

                return RedirectToAction("Lista");
            }


            var categorias = new Categorias();

            var ListaCategorias = categorias.Lista();

            viewModel.Categorias = Mapper.Map<IList<CategoriaViewModel>>(ListaCategorias);

            return View(viewModel);
        }
    }
}
