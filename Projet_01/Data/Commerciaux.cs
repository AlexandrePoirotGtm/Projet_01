﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;

namespace Data
{
	public class Commerciaux : Personne,ILogger
	{
        public string Pseudo { get; set; }
        public string MotDePasse { get; set; }
	}
}