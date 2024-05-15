using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Progetto_Meteo_Trentino.Models;
using Progetto_Meteo_Trentino.Services;
using Progetto_Meteo_Trentino.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
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


        [HttpGet("RichiestaCitta")]
        public IActionResult RichiestaCitta()
        {
            var viewModel = new RichiestaCitta();
            return View(viewModel);
        }

        [HttpGet("RichiestaMeteoGiorno")]
        public IActionResult RichiestaMeteoGiorno()
        {
            var viewModel = new RichiestaMeteoGiorno();
            return View(viewModel);
        }

        [HttpGet("MeteoDelGiorno/{localita}/{giorno}")]
        public async Task<IActionResult> MeteoDelGiorno(string localita, DateTime giorno)
        {
            var meteoGiorno = await this._meteoService.MeteoDelGiorno(localita, giorno);
            if (meteoGiorno == null)
            {
                return NotFound();
            }

            var viewModel = new MeteoDelGiornoView();
            viewModel.localita = localita;
            viewModel.giorno = meteoGiorno;
            viewModel.fasce = meteoGiorno.fasce;

            return View(viewModel);
        }






        [HttpGet("VisualizzaMeteo")]
        public async Task<IActionResult> VisualizzaMeteo(string localita = "/")
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
                previsione = bollettino.previsione
            };

            return View(viewModel);
        }



         [HttpPost("RichiestaCitta")]

        public IActionResult RichiestaCitta([FromForm] RichiestaCitta richiesta)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("VisualizzaMeteo", "Meteo", new { localita = richiesta.citta });
            }
            return View(richiesta);
        }

        [HttpPost("RichiestaMeteoGiorno")]

        public IActionResult RichiestaMeteoGiorno([FromForm] RichiestaMeteoGiorno richiesta)
        {
            if(ModelState.IsValid)
            {

                
                return RedirectToAction("MeteoDelGiorno", "Meteo", new { localita = richiesta.citta, giorno = richiesta.giorno });
            }
            return View(richiesta);
        }
    }
}




