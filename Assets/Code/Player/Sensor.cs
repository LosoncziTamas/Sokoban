using UnityEngine;

namespace Code.Player
{
    [RequireComponent(typeof(Collider))]
    public class Sensor : MonoBehaviour
    {
        public bool Colliding { private set; get; }
        
        private void OnTriggerEnter(Collider other)
        {
            Colliding = true;
        }

        private void OnTriggerExit(Collider other)
        {
            Colliding = false;
        }

        private void OnTriggerStay(Collider other)
        {
            Colliding = true;
        }
    }
}