using UnityEngine;
using UnityEngine.EventSystems;


namespace LootSyst
{
    [SerializeField]
    public class Loot
    {
        public string name;
        public string rare;
        public string type;
        public int count;

    }
    public class properties
    {
        public string[] names = new[] { "Bandage", "Can", "Snow"};
        public string[] rares = new[] { "Common", "Uncommon", "Rare" };
        public string[] types = new[] { "Heal", "Trash", "Resources" };



    }

}

