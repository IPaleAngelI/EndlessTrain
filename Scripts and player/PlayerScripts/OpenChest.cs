using UnityEngine;

namespace LootSyst
{
    public class OpenChest : MonoBehaviour
    {
        [SerializeField] private Chest chest;

        private bool isOpen = false;
        private bool hasOpener;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<ChestOpener>() != null)
                hasOpener = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<ChestOpener>() != null)
                hasOpener = false;
        }

        private void Update()
        {
            if (isOpen)
                return;

            if (hasOpener && Input.GetKeyDown(KeyCode.E))
            {
                chest.Open();
                isOpen = true;
            }
        }

    }
}