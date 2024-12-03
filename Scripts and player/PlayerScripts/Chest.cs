using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using LootSyst;
using static UnityEditor.Progress;

namespace LootSyst
{
    [SerializeField]
    public class Chest : MonoBehaviour
    {
        private readonly int OpenTrigger = Animator.StringToHash("Open");

        [SerializeField] private Animator animator;
        public List<Loot> loot;
        public Loot[] loots;
        private properties properties = new properties(); // ������������� properties
        private Inventory inventory = new Inventory();

        public void Start()
        {
            int items = Random.Range(1, 1);
            loots = new Loot[items]; // ������������� ������� loots
            for (int i = 0; i < items; i++)
            {
                Loot item = new Loot();
                item.name = properties.names[Random.Range(0, properties.names.Length)];
                item.rare = properties.rares[Random.Range(0, properties.rares.Length)];
                item.type = properties.types[Random.Range(0, properties.types.Length)];
                item.count = Random.Range(0, 20);

                loots[i] = item;
            }
        }

        public void Update()
        {
            for (int i = 0; i < loots.Length; i++) // ���������� �������
            {
                if (loots[i] != null && loots[i].count <= 0) // �������� �� null
                {
                    loots[i] = null;
                }
                if (loots[i] !=null)
                print(loots[i].name + loots[i].rare + loots[i].type + loots[i].count);
                else { print("Chest is empty"); }
            }
            
        }

        public void Open()
        {
            inventory.inv[0] = loots[0];
            loots[0] = null;
            

            
        }
    }
}