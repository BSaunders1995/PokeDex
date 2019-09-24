using PokemonManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulpixManager.Models
{
    public class Pokedex
    {
        public string Name;
        ICollection<Pokemon> PokeList { get; set; }
    }
}
