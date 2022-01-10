using Code.Common;
using UnityEngine;

namespace Code.Player
{
    [RequireComponent(typeof(Collider))]
    public class Sensor : MonoBehaviour
    {
        public bool Blocked { private set; get; }
        public GameObject MovableGameObject { private set; get; }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == PhysicsUtils.MovableLayer)
            {
                MovableGameObject = other.gameObject;
            }
            else
            {
                Blocked = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Blocked = false;
            MovableGameObject = null;
        }
    }
}