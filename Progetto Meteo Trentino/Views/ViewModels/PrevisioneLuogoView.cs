﻿using Progetto_Meteo_Trentino.Models;

namespace Progetto_Meteo_Trentino.Views.ViewModels
{
    public class PrevisioneLuogoView
    {
        public string localita { get; set; }
        public int quota { get; set; }
        public Giorno[] giorni { get; set; }
    }
}
