using UnityEditor;
using UnityEngine;


namespace LootSyst
{

    [SerializeField]
    public class Inventory : MonoBehaviour
    {
        public Loot[] inv;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            inv = new Loot[10];

        }

        // Update is called once per frame
        void Update()
        {
            if (inv == null) return;
            print(inv[0].name + inv[0].rare + inv[0].type + inv[0].count);

        }
    }
}
