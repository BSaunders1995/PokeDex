namespace PokemonManager.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public int HealthPoints { get; set; }
        public int BattlePoints { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Weight { get; set; }
        public string Nickname { get; set; }
    }
}
