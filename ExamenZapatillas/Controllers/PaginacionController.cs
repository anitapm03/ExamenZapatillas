using ExamenZapatillas.Models;
using ExamenZapatillas.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExamenZapatillas.Controllers
{
    public class PaginacionController : Controller
    {
        private RepositoryZapatillas repo;
        public PaginacionController(RepositoryZapatillas repo)
        {
            this.repo = repo;
        }

        /*METODO PARA PAGINAR UNA SOLA ZAPATILLA
        public async Task<IActionResult> PaginarZapatilla
            (int? posicion, int idzapa)
        {
            if(posicion == null)
            {
                posicion = 1;
            }
            ModelPaginarImagen model = await
                this.repo.GetImagenZapaAsync
                (posicion.Value, idzapa);
            Zapatilla zapa = await this.repo.FindZapatilla(idzapa);

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
        */

        
    }
}

