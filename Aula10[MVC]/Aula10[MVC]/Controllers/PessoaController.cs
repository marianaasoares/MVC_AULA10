﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula10_MVC_.Models;
using Aula10_MVC_.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Aula10_MVC_.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaMdfRepository _pessoaRepository;

        public PessoaController()
        {
            _pessoaRepository = new PessoaMdfRepository();
        }

        public IActionResult Index()
        {
            var pessoas = _pessoaRepository.GetAll();

            return View(pessoas);
            
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaModel newPessoaModel)
        {
            try
            {
                // TODO: Add insert logic here
                _pessoaRepository.Add(newPessoaModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}