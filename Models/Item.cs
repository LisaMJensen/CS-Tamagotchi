using System.Collections.Generic;

namespace TamagotchiList.Models
{
    public class Tamagotchi
    {
        public string Description { get; set; }
        public int Id { get; }
        private static List<Tamagotchi> _instances = new List<Tamagotchi> { };

        public Tamagotchi(string description)
        {
            Description = description;
            _instances.Add(this);
            Id = _instances.Count;
        }

        public static List<Tamagotchi> GetAll()
        {
            return _instances;
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static Tamagotchi Find(int searchId)
        {
            return _instances[searchId - 1];
        }

    }
}