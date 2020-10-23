using CRMALL.Domain.Entities;
using CRMALL.Domain.Util;
using CRMALL.Service.Interface.Clientes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRMALL.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult Index(int currentPage = 1, int pageSize = 10) // string searchString,
        {
            // ViewData["CurrentFilter"] = searchString;

            var clientes = _clienteService.GetAll();

            //if (!string.IsNullOrEmpty(searchString))
            //    clientes = _clienteService.FilterByName(searchString);

            return View(PaginatedList<Cliente>.Create(clientes.AsNoTracking(), currentPage, pageSize));
        }

        public IActionResult AddOrEdit(long id = 0)
        {
            if (id == 0)
                return View(new Cliente());
            else
                return View(_clienteService.GetById(id));
        }

        [HttpPost]
        public IActionResult AddOrEdit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteService.AddOrEdit(cliente);

                return Json(new { result = "Redirect", url = Url.Action("Index", "Cliente") });
            }
            return View(cliente);
        }

        public IActionResult Delete(long id)
        {
            _clienteService.Delete(id);

            return Json(new { result = "Redirect", url = Url.Action("Index", "Cliente") });
        }

        //[HttpGet]
        //public JsonResult SelectListCliente([FromRoute]long? id)
        //{
        //    return Json(_clienteService.SelectListCliente((long?)id));
        //}
    }
}