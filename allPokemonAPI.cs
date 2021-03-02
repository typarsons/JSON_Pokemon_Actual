using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_Pokemon_
{
    public class allPokemonAPI
    {
        public List<ResultObject> results { get; set; }
       
    }
    public class ResultObject
    { //this is the correct file. build from here
        public string name { get; set; }
        public string url { get; set; }
        public string resultObject { get; set; }
        public override string ToString()
        {
            return name.ToString();
        }

    }
    public class SelectedPokemo
    {
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public PokemonSprites sprites { get; set; }
    }
    public class PokemonSprites
    {

        public string front_default { get; set; }
        public string back_default { get; set; }
       
       
    }

}

