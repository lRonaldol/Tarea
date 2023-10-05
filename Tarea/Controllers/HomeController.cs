using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea.Model.Entities;
using Tarea.Model.ViewModels;

namespace Tarea.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            
            
            AnimalesContext context = new ();
            IndexViewModel viewModel = new IndexViewModel ();
            var datos = context.Clase.OrderBy(x => x.Id);
            viewModel.Clase = datos.Select(x => new ClaseModel
            {
                id = x.Id,
                nombre = x.Nombre,
                descripcion= x.Descripcion
            });
            return View(viewModel);
        }
        public IActionResult Especies(string id)
        {
            AnimalesContext context = new ();
            var Especies = context.Clase.Where(x => x.Nombre == id).OrderBy(x => x.Nombre)
                  .Include(x => x.Especies).Select(x => new EspeciesViewModel
                  {
                      Id = x.Id,
                      Especies = x.Especies,
                      Nombre = x.Nombre ?? ""
                  }).FirstOrDefault();


            if (Especies == null)
            {

                return RedirectToAction("Index");
            }

            return View(Especies);
        }

        public IActionResult Especie(string id)
        {
            AnimalesContext context = new();
            var Especie = context.Especies.Where(x => x.Especie.Replace(" ","") == id)
                .OrderBy(x => x.Especie).Include(x => x.IdClaseNavigation).Select(x => new EspecieViewModel
                {
                    Id = x.Id,
                    Clase = x.IdClaseNavigation == null ? "" : x.IdClaseNavigation.Nombre ?? "",
                    Nombre = x.Especie,
                    Peso = (double)(x.Peso !=null ? x.Peso:0),
                    Tamaño = (int)(x.Tamaño != null ? x.Tamaño : 0) ,
                    Observacion = x.Observaciones ?? "",
                    Habitad = x.Habitat ?? ""


                }).First();

            if (Especie == null)
            {
                return RedirectToAction("Index");
            }
            return View(Especie);
        }

    }
}
