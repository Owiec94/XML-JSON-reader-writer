﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_JSON_reader_writer
{
    public class Car
    {
       
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }

        [JsonIgnore]
        public int Nbr { get; set; }
    }
}
