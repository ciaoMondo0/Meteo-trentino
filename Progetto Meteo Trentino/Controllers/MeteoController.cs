using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Progetto_Meteo_Trentino.Models;
using Progetto_Meteo_Trentino.Services;
using Progetto_Meteo_Trentino.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.ServiceModel;
using System.Threading.Tasks;



namespace Progetto_Meteo_Trentino.Controllers
{

    
    public class MeteoController : Controller
    {
       


        private readonly MeteoService _meteoService;

        public MeteoController()
        {

            _meteoService = new MeteoService();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            var bollettino = await _meteoService.Meteo();

            if (bollettino == null)
            {
                return NotFound(); 
            }

           
            var viewModel = new BollettinoMeteoView
            {
                fontedacitare = bollettino.fontedacitare,
                codiceipatitolare = bollettino.codiceipatitolare,
                nometitolare = bollettino.nometitolare,
                codiceipaeditore = bollettino.codiceipaeditore,
                nomeeditore = bollettino.nomeeditore,
                dataPubblicazione = bollettino.dataPubblicazione,
                idPrevisione = bollettino.idPrevisione,
                evoluzione = bollettino.evoluzione,
                evoluzioneBreve = bollettino.evoluzioneBreve
            };

           
            return View(viewModel);
        }


        [HttpGet("RichiestaCitta")]
        public async Task<IActionResult> RichiestaCitta()
        {
            var bollettino = await _meteoService.Meteo();
            if (bollettino == null)
            {
                return NotFound();
            }

            var viewModel = new RichiestaCitta
            {
                CittaLista = bollettino.previsione.Select(p => p.localita).Distinct().ToList()
            };

            return View(viewModel);
        }

        [HttpGet("RichiestaMeteoGiorno")]
        public async Task<IActionResult> RichiestaMeteoGiorno()
        {
            var bollettino = await _meteoService.Meteo();
            if (bollettino == null)
            {
                return NotFound();
            }

            var viewModel = new RichiestaMeteoGiorno
            {
                CittaLista = bollettino.previsione.Select(p => p.localita).Distinct().ToList()
            };

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
        public async Task<IActionResult> VisualizzaMeteo(string localita)
        {
            var previsione = await this._meteoService.PrevisioneLuogo(localita);
            if (previsione == null)
            {
                return NotFound();
            }

            var viewModel = new PrevisioneLuogoView();
            viewModel.localita = localita;
            viewModel.quota = previsione.quota;
            viewModel.giorni = previsione.giorni;

            return View(viewModel);
        }



         [HttpPost("RichiestaCitta")]

        public IActionResult RichiestaCitta([FromForm] RichiestaCitta richiesta)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("VisualizzaMeteo", "Meteo", new { localita = richiesta.cittaSelezionata });
            }
            return View(richiesta);
        }

        [HttpPost("RichiestaMeteoGiorno")]

        public IActionResult RichiestaMeteoGiorno([FromForm] RichiestaMeteoGiorno richiesta)
        {
            if(ModelState.IsValid)
            {
                string dataFormattata = richiesta.giorno.ToString("yyyy-MM-dd");


                return RedirectToAction("MeteoDelGiorno", "Meteo", new { localita = richiesta.cittaSelezionata, giorno = dataFormattata });
            }
            return View(richiesta);
        }
    }
}




