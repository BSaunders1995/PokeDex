using PokemonManager.Data;
using PokemonManager.Models;
using System;
using VulpixManager.View;

namespace PokemonManager.View
{
    public class PokemonView
    {
        ConsoleIO io = new ConsoleIO();
        private readonly PokemonManagerRepository repo;
        public PokemonView(PokemonManagerRepository repo)
        {
            this.repo = repo;
        }

        public int GetMenuChoice()
        {
            bool validFormat = false;
            int menuChoice = 0;

            while (!validFormat)
                try
                {
                    string readIn = Console.ReadLine();
                    menuChoice = Int32.Parse(readIn);
                    validFormat = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a REAL number.");
                    validFormat = false;
                }

            return menuChoice;
        }

        public Pokemon CreatePokemon()
        {
            Pokemon pokemon = new Pokemon();
            pokemon.Name = io.GetStringInput("Please enter a name.");
            pokemon.Nickname = io.GetStringInput("Please enter a nickname.");
            pokemon.Type = io.GetStringInput("Please enter a type.");
            pokemon.Weight = io.GetStringInput("Please enter the weight.");
            pokemon.HealthPoints = io.GetIntegerInput("Please enter how much health (as a number) the pokemon has");
            pokemon.Description = io.GetStringInput("Please give a description of the pokemon.");
            return pokemon;
        }

        public void DisplayPokemon(Pokemon pokemon)
        {
            Console.WriteLine($"*********************************************");
            Console.WriteLine($"ID           : {pokemon.Id}");
            Console.WriteLine($"Name         : {pokemon.Name}");
            Console.WriteLine($"Type         : {pokemon.Type}");
            Console.WriteLine($"Weight       : {pokemon.Weight}");
            Console.WriteLine($"Nickname     : {pokemon.Nickname}");
            Console.WriteLine($"Health Points: {pokemon.HealthPoints}");
            Console.WriteLine($"Description  : {pokemon.Description}");
        }

        public Pokemon EditPokemonInfo(Pokemon oldPokemon)
        {
            Pokemon pokemon = new Pokemon();
            Console.WriteLine($"Current name         : {oldPokemon.Name}");
            pokemon.Name = io.GetStringInput("Please enter a new name.");

            Console.WriteLine($"Current nickname     : {oldPokemon.Nickname}");
            pokemon.Nickname = io.GetStringInput("Please enter a new nickname.");

            Console.WriteLine($"Current type         : {oldPokemon.Type}");
            pokemon.Type = io.GetStringInput("Please enter a new type.");

            Console.WriteLine($"Current weight       : {oldPokemon.Weight}");
            pokemon.Weight = io.GetStringInput("Please enter the new weight.");

            Console.WriteLine($"Current health points: {oldPokemon.HealthPoints}");
            pokemon.HealthPoints = io.GetIntegerInput("Please enter how much health (as a number) the pokemon now has");

            Console.WriteLine($"Current desciprtion: {oldPokemon.Description}");
            pokemon.Description = io.GetStringInput("Please give a description of the pokemon.");
            return pokemon;
        }

        public int SearchPokemon()
        {
            Console.WriteLine("Please enter the Id of the pokemon you'd like to find");
            return GetMenuChoice();
        }

        public bool ConfirmRemovePokemon()
        {
            if (GetMenuChoice() != 1)
                return false;
            else
                return true;
        }


    }
}
