using ExamenZapatillas.Models;
using ExamenZapatillas.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExamenZapatillas.Controllers
{
    public class ZapatillasController : Controller
    {
        private RepositoryZapatillas repoZapas;

        public ZapatillasController(RepositoryZapatillas repoZapas)
        {
            this.repoZapas = repoZapas;
        }
    
        //mostraremos una vista con una tabla de zapatillas
        public async Task<IActionResult> Index()
        {
            List<Zapatilla> zapas = await
                this.repoZapas.GetZapas();
            return View(zapas);
        }

        public async Task<IActionResult> Detalles
            (int? posicion, int idzapa)
        {
            if (posicion == null)
            {
                posicion = 1;
            }

            ModelPaginarImagen model = await
                this.repoZapas.GetImagenZapaAsync(posicion.Value, idzapa);

            ViewData["ZAPATILLASELECCIONADA"] = model.zapatilla;
            return View();
        }
       
        public async Task<IActionResult> _ImagenesPartial
            (int? posicion, int idzapa)
        {
            if (posicion == null)
            {
                posicion = 1;
            }
            ModelPaginarImagen model = await
                this.repoZapas.GetImagenZapaAsync
                (posicion.Value, idzapa);
            Zapatilla zapa = await this.repoZapas.FindZapatilla(idzapa);

            ViewData["ZAPATILLASELECCIONADA"] = zapa;
            ViewData["REGISTROS"] = model.numRegistros;
            ViewData["ZAPA"] = idzapa;

            int siguiente = posicion.Value + 1;

            if (siguiente > model.numRegistros)
            {
                siguiente = model.numRegistros;
            }

            int anterior = posicion.Value - 1;
            if (anterior < 1)
            {
                anterior = 1;
            }

            ViewData["ULTIMO"] = model.numRegistros;
            ViewData["SIGUIENTE"] = siguiente;
            ViewData["ANTERIOR"] = anterior;
            ViewData["POSICION"] = posicion;

            return View(model.Imagen);
        }
    }
}
