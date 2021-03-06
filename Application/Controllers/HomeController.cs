using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Models;
using Data.Interfaces;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoRepository _todoRepository;

        public HomeController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public IActionResult Index()
        {            
            return View(_todoRepository.GetAll());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Entities.ToDo obj)
        {
            _todoRepository.Add(obj);
            return View("Index", _todoRepository.GetAll());
        }

        public IActionResult Editar(int id)
        {
            Entities.ToDo todo = _todoRepository.Get(id);
            return View(todo);
        }

        [HttpPost]
        public IActionResult Editar(Entities.ToDo obj)
        {
            _todoRepository.Update(obj);
            return View("Index", _todoRepository.GetAll());
        }

        public IActionResult Remover(int id)
        {
            Entities.ToDo todo = _todoRepository.Get(id);
            return View(todo);
        }
                
        public IActionResult ConfirmaRemover(int id)
        {
            _todoRepository.Remove(_todoRepository.Get(id));
            return View("Index", _todoRepository.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
