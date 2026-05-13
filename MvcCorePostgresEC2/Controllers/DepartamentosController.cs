using Microsoft.AspNetCore.Mvc;
using MvcCorePostgresEC2.Models;
using MvcCorePostgresEC2.Repositories;
using System.Threading.Tasks;

namespace MvcCorePostgresEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private DepartamentoRepository repo;
        public DepartamentosController(DepartamentoRepository repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            List<Departamento> dept = await this.repo.LoadDepartamentosAsync();
            return View(dept);
        }
        public async Task<IActionResult> Details(int id)
        {
            Departamento dept = await this.repo.FindDepartamentoAsync(id);
            return View(dept);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Departamento dept)
        {
            await this.repo.CreateDepartamentoAsync(dept);
            return RedirectToAction("Index");
        }
    }
}
