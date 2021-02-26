using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_Pokemon_
{
    public class allPokemonAPI
    {
        public List<ResultObject> results { get; set; }
        public List<PokemonSprites> sprites { get; set; }
    }
    public class ResultObject
    {
        public string name { get; set; }
        public string url { get; set; }
        public string resultObject { get; set; }
        public string height { get; set; }
        public override string ToString()
        {
            return name.ToString();
        }
    }
    public class PokemonSprites
    {
        
        public string back_default { get; set; }
        public string front_default { get; set; }
        public string pokemonSprites { get; set; }
    }
    public class Height
    {
        public string height { get; set; }
        public override string ToString()
        {
            return height.ToString();
        }
    }
    public class Weight
    {
        public string weight { get; set; }
        public override string ToString()
        {
            return weight.ToString();
        }
    }
}

