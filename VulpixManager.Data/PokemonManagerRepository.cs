using PokemonManager.Models;
using System.Collections.Generic;
using System.Linq;

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
            //Call your list of objects, add the method parameter (Pokemon input)
            input.Id = data.Count();
            data.Add(input);
            return new Pokemon();
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

        public void Update(int id)
        {
            data.ToList().FirstOrDefault();
        }

        public void Delete(int id)
        {

        }
    }
}
