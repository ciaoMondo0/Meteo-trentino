﻿using ModelliMeteo;

namespace Progetto_Meteo_Trentino.ViewModels
{
    public class PrevisioneLuogoView
    {
        public string localita { get; set; }
        public int quota { get; set; }
        public Giorno[] giorni { get; set; }
    }
}
