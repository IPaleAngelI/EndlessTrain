using UnityEngine;
using Unity;

namespace Starter.ThirdPersonCharacter
{
    
    public class movewithtrain : MonoBehaviour
    {
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
           

        }

        // Update is called once per frame
        void Update()
        {

        }
        Player player = new Player();
        private void OnTriggerEnter(Collider other)
        {
            var objTag = other.gameObject.tag;

            if (objTag == "Train")
            {
                Debug.Log(objTag);
                this.transform.parent = other.transform;
                player._moveVelocity = (Vector3.zero);
            }

        }
        private void OnCollisionEnter(Collision collision)
        {
            var objTag = collision.gameObject.tag;
            Debug.Log(objTag);
            if (objTag == "Train")
            {
                this.transform.parent = collision.transform;
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            var objTag = collision.gameObject.tag;
            Debug.Log(objTag);
            if (objTag == "Train")
            {
                this.transform.parent = null;
            }
        }
    }
}
