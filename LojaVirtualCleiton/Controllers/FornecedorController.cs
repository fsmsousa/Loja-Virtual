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
    public class FornecedorController : Controller
    {
        public ActionResult Lista()

        {
            var fornecedores = new Fornecedores();

            var listaFornecedores = fornecedores.Lista();

            var lista = Mapper.Map<IList<FornecedorViewModel>>(listaFornecedores);

            return View(lista);     
              
        }

        public ActionResult Editar(Guid? id = null)
        {
            if(id != null)
            {
                var fornecedores = new Fornecedores();

                var fornecedor = fornecedores.Por(id);

                var viewModel = Mapper.Map<FornecedorViewModel>(fornecedor);

                return View(viewModel);
            }

            return View();
        }

        public ActionResult Apagar(Guid id)
        {
                var fornecedores = new Fornecedores();

                fornecedores.Apagar(id);

                return RedirectToAction("Lista");

        }
        
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(FornecedorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var fornecedores = new Fornecedores();
                var fornecedor = Mapper.Map<Fornecedor>(viewModel);
                fornecedores.Salvar(fornecedor);
                return RedirectToAction("Lista");
            }

            return View(viewModel);
        }
    }
}
