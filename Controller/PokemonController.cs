using PokemonManager.Data;
using PokemonManager.Models;
using PokemonManager.View;
using System;

namespace PokemonManager.Controller
{
    public class PokemonController
    {
        PokemonView view;
        PokemonManagerRepository repo;
        public PokemonController()
        {
            repo = new PokemonManagerRepository();
            view = new PokemonView(repo);
        }

        public void Run()
        {
            Console.WriteLine("Thanks for choosing Pokemon Manager.");
            Console.WriteLine("Here you can view your PokeDex and see what you've entered and caught. \n" +
                "Feel free to add, edit, view, and remove information that you've entered as well. \n" +
                "Press enter to continue.");
            Console.ReadLine();
            bool exit = false;

            do
            {
                DisplayMenu();
                int menuChoice = view.GetMenuChoice();

                switch (menuChoice)
                {
                    case 1:
                        CreatePokemon();
                        break;
                    case 2:
                        DisplayPokemon();
                        break;
                    case 3:
                        SearchPokemon();
                        break;
                    case 4:
                        EditPokemon();
                        break;
                    case 5:
                        RemovePokemon();
                        break;
                    case 6:
                        Console.WriteLine("Have a nice day! :)");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("You didn't choose a valid number!!!");
                        break;

                }
            } while (!exit);
        }

        private void CreatePokemon()
        {
            var pokemon = view.CreatePokemon();
            var returned = repo.Create(pokemon);
            Console.WriteLine("Successfully added Pokemon to the PokeDex:");
            Console.WriteLine($"Id           : {returned.Id}");
            Console.WriteLine($"Name         : {returned.Name}");
            Console.WriteLine($"Type         : {returned.Type}");
            Console.WriteLine($"Description  : {returned.Description}");
            Console.WriteLine($"Health Points: {returned.HealthPoints}");
            Console.WriteLine("");
            Continue();
        }

        private void DisplayPokemon()
        {
            Console.WriteLine("*LIST OF POKEMON*");
            var pokemonList = repo.ReadAll();
            Console.WriteLine("Number of pokemon documented: " + pokemonList.Count);
            for (int i = 0; i < pokemonList.Count; i++)
            {
                view.DisplayPokemon(pokemonList[i]);
            }
            Continue();
        }

        private void SearchPokemon()
        {
            DisplayPokemon();
            int tryCount = 0;
            var foundPokemon = new Pokemon();
            while(foundPokemon.Id == 0)
            {
                int id = view.SearchPokemon();
                foundPokemon = repo.ReadByID(id);
                tryCount++;

                if(tryCount == 10)
                {
                    Console.WriteLine("That's enough attempts. Let's try something else.");
                    return;
                }
            }

            Console.WriteLine($"Name         : {foundPokemon.Name}");
            Console.WriteLine($"Nickname     : {foundPokemon.Nickname}");
            Console.WriteLine($"Type         : {foundPokemon.Type}");
            Console.WriteLine($"Weight       : {foundPokemon.Weight}");
            Console.WriteLine($"Description  : {foundPokemon.Description}");
            Console.WriteLine($"Health Points: {foundPokemon.HealthPoints}");
        }

        private void EditPokemon()
        {
            DisplayPokemon();            
            int id = view.SearchPokemon();
            var oldPokemon = repo.ReadByID(id);
            Pokemon newPokemon = view.EditPokemonInfo(oldPokemon);
            repo.Update(newPokemon);

            Console.WriteLine("Successfully updated Pokemon.");
            Console.WriteLine($"Old Name: {oldPokemon.Name} -> New Name: {newPokemon.Name}");
            Console.WriteLine($"Old Type: {oldPokemon.Type} -> New Type: {newPokemon.Type}");
            Console.WriteLine($"Old Weight: {oldPokemon.Weight} -> New Weight: {newPokemon.Weight}");
            Console.WriteLine($"Old Description: {oldPokemon.Description} -> New Description: {newPokemon.Description}");
            Console.WriteLine($"Old Health Points: {oldPokemon.HealthPoints} -> New Health Points: {newPokemon.HealthPoints}");
            Console.WriteLine("");
            Continue();
        }

        private void RemovePokemon()
        {
            DisplayPokemon();
            int id = view.SearchPokemon();

            Console.WriteLine("Are you sure you want to remove this Pokemon record? \n" +
                "Press 1 to confirm");
            var confirmed = view.ConfirmRemovePokemon();

            if (confirmed) {
                repo.Delete(id);
                Console.WriteLine("Successfully delete pokemon");
                Continue();
            }
            else
            {
                Console.WriteLine("Not deleting.");
                Continue();
            }

        }

        private void Continue()
        {
            Console.WriteLine("Press 'Enter' to continue");
            Console.ReadLine();
            Console.WriteLine("");
        }

        public void DisplayMenu()
        {
            Console.WriteLine("What would you like to do? Press the corresponding number and then press enter.");
            Console.WriteLine("1. Create Pokemon");
            Console.WriteLine("2. List All Pokemon");
            Console.WriteLine("3. Find Pokemon by ID");
            Console.WriteLine("4. Edit Pokemon");
            Console.WriteLine("5. Remove Pokemon");
            Console.WriteLine("6. Exit");
        }
    }
}
