using PokemonManager.Models;
using System.Collections.Generic;

namespace PokemonManager.Data
{
    public class PokemonManagerRepository
    {
        private List<Pokemon> data;

        public PokemonManagerRepository()
        {
            if (data == null)
            {
                data = new List<Pokemon>();
            }
        }
        public Pokemon Create(Pokemon input)
        {
            int id = 0;
            for (int i = 0; i < data.Count; i++)
                id = data[i].Id;

            input.Id = id + 1;
            data.Add(input);
            return input;
        }

        public List<Pokemon> ReadAll()
        {
            return data;
        }

        public Pokemon ReadByID(int id) // use looping
        {
            //Linq
            //return data.Where(m => m.Id == id).FirstOrDefault();

            //Foreach Common
            //foreach (Pokemon poke in data) //Loop through your List of Objects (data<Pokemon>)
            //{
            //    if (poke.Id == id) //Check to see if that object is equal to the id that was passed in
            //    {
            //        return poke; //Return that object
            //    }
            //}

            //For Loop
            var pokemon = new Pokemon();
            for (int i = 0; i < data.Count; i++) //Loop through your List of Objects (data<Pokemon>)
            {
                if (data[i].Id == id) //Check to see if that object is equal to the id that was passed in
                {
                    pokemon = data[i]; //Return that object of that list
                }
            }
            return pokemon;
        }

        public void Update(Pokemon pokemon)
        {
            var pokemonInList = new Pokemon();
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Id == pokemon.Id) { pokemonInList = data[i]; }
            }
            pokemonInList = pokemon;
        }

        public void Delete(int id)
        {
            var pokemon = new Pokemon();
            for (int i = 0; i < data.Count; i++) //Loop through your List of Objects (data<Pokemon>)
            {
                if (data[i].Id == id) //Check to see if that object is equal to the id that was passed in
                {
                    data.Remove(data[i]); //Remove that object from the list
                }
            }
        }
    }
}
