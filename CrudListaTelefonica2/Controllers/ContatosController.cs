using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrudListaTelefonica2.DAO;
using CrudListaTelefonica2.Models;

namespace CrudListaTelefonica2.Controllers
{
    public class ContatosController : Controller
    {
        public IActionResult Index()
        {

            ContatosDAO dao = new ContatosDAO();
            return View(dao.Listagem());

        }
        public IActionResult Form()
        {
            return View();
        }
        public IActionResult Create(ContatosViewModel contatos)
        {
            try {
                ContatosDAO dao = new ContatosDAO();
                if (contatos.Id == 0)
                {
                    dao.Inserir(contatos);
                }
                else
                {
                    dao.Alterar(contatos);
                }
                return RedirectToAction("Index");
            }
            catch(Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));

            }
        }

        public IActionResult Edit(int id)
        {
            try {
                ContatosDAO dao = new ContatosDAO();
                var contato = dao.Consulta(id);
                return View("Form", contato);
                }
            catch(Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                var dao = new ContatosDAO();
            dao.Excluir(id);
            return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
    }
}
