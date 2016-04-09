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

            var lista = Mapper.Map<IList<ProdutoViewModel>>(listaProdutos);

            return View(lista);     
              
        }

        public ActionResult Editar(Guid? id = null)
        {
            if(id != null)
            {
                var produtos = new Produtos();

                var produto = produtos.Por(id);

                var viewModel = Mapper.Map<ProdutoViewModel>(produto);

                return View(viewModel);
            }

            return View();
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

            return View(viewModel);
        }
    }
}
