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
    public class CategoriaController : Controller
    {
        public ActionResult Lista()

        {
            var categorias = new Categorias();

            var listaCategorias = categorias.Lista();

            var lista = Mapper.Map<IList<CategoriaViewModel>>(listaCategorias);

            return View(lista);     
              
        }

        public ActionResult Editar(Guid? id = null)
        {
            if(id != null)
            {
                var categorias = new Categorias();

                var categoria = categorias.Por(id);

                var viewModel = Mapper.Map<CategoriaViewModel>(categoria);

                return View(viewModel);
            }

            return View();
        }

        public ActionResult Apagar(Guid id)
        {
                var categorias = new Categorias();

                categorias.Apagar(id);

                return RedirectToAction("Lista");

        }
        
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CategoriaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var categorias = new Categorias();
                var categoria = Mapper.Map<Categoria>(viewModel);
                categorias.Salvar(categoria);
                return RedirectToAction("Lista");
            }

            return View(viewModel);
        }
    }
}
