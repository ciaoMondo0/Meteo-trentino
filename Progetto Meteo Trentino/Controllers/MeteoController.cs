using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Progetto_Meteo_Trentino.Models;
using Progetto_Meteo_Trentino.Services;
using Progetto_Meteo_Trentino.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Progetto_Meteo_Trentino.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MeteoController : Controller
    {
        /*
        [HttpGet("{localita}")]
        public async Task<IActionResult> getMeteo(string localita)
        {
            var bollettino = await MeteoService.Meteo(localita);
            if (bollettino == null)
            {
                return NotFound();
            }
            return Ok(bollettino);
        }*/


        private readonly MeteoService _meteoService;

        public MeteoController()
        {

            _meteoService = new MeteoService();
        }


        [HttpGet]
        public IActionResult RichiestaCitta()
        {
            var viewModel = new RichiestaCitta();
            return View(viewModel);
        }


        [HttpGet("{localita}")]
        public async Task<IActionResult> VisualizzaMeteo(string localita)
        {
            var bollettino = await this._meteoService.Meteo(localita);
            if (bollettino == null)
            {
                return NotFound();
            }

            var viewModel = new BollettinoMeteoView
            {
                dataPubblicazione = bollettino.dataPubblicazione.ToString(),
                idPrevisione = bollettino.idPrevisione,
                evoluzione = bollettino.evoluzione,
                evoluzioneBreve = bollettino.evoluzioneBreve,
                previsioni = bollettino.previsioni
            };

            return View(viewModel);
        }




        [HttpPost]

        public IActionResult RichiestaCitta([FromForm] RichiestaCitta citta)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("VisualizzaMeteo", "Meteo", new { localita = citta.citta });
            }
            return View("RichiestaCitta", citta);
        }
    }
}




