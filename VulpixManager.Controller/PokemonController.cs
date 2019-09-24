using PokemonManager.Data;
using PokemonManager.Models;
using PokemonManager.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonManager.Controller
{
    public class PokemonController
    {
        PokemonView view;
        PokemonManagerRepository repo;
        public PokemonController()
        {
            view = new PokemonView();
            repo = new PokemonManagerRepository();
        }

        public void Run()
        {
            Console.WriteLine("Thanks for choosing Pokemon Manager.");
            Console.WriteLine("Please choose what to do with Pokemon. Press the corresponding number and then press enter. Press enter to continue.");
            Console.ReadLine();

            Console.WriteLine("1. Create Pokemon");
            Console.WriteLine("2. List All Pokemon");
            Console.WriteLine("3. Find Pokemon by ID");
            Console.WriteLine("4. Edit Pokemon");
            Console.WriteLine("5. Remove Pokemon");

            int menuChoice = int.TryParse(Console.ReadLine(), 0);
            switch (menuChoice)
            {
                case 0:
                    Console.WriteLine("Check your input bud");
                    break;
                case 1:
                    CreatePokemon();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("You didn't choose a valid number!!!");
                    break;
            }

            // Call method in view to get menu choice (return int)
            // switch statement to decide which method to call (call one of the other methods in this class) 
        }

        private void CreatePokemon()
        {
            // 1. Call method in view to get new pokemon info (return Pokemon) need object to hold that data
            // 2. Pass that pokemon to the repository to create
            var p = new Pokemon();
            Console.WriteLine("*ADD POKEMON*");
            Console.WriteLine("Name: ");
            p.Name = Console.ReadLine();
            Console.WriteLine("Type: ");
            p.Type = Console.ReadLine();
            Console.WriteLine("Weight: ");
            p.Weight = Console.ReadLine();
            Console.WriteLine("Nickname: ");
            p.Nickname = Console.ReadLine();
            Console.WriteLine("Health Points: ");
            p.HealthPoints = int.Parse(Console.ReadLine());
            Console.WriteLine("Battle Points: ");
            p.BattlePoints = int.Parse(Console.ReadLine());
            repo.Create(p);
        }

        private void DisplayPokemon()
        {

        }

        private void SearchPokemon()
        {
            // 1. Call method in view to get id from user
            // 2. Pass that id to data layer to find pokemon by that id (will get a pokemon)
            // 3. Pass pokemon to view to display
        }

        private void EditPokemon()
        {

        }

        private void RemovePokemon()
        {

        }

    }
}
