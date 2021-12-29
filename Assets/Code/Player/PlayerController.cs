using Code.GameInput;
using UnityEngine;

namespace Code.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private PlayerSensors _sensors;
        [SerializeField] private Rigidbody _rigidbody;

        private void Update()
        {
            if (_playerInput.Left)
            {
                if (!_sensors.CanMoveLeft())
                {
                    Debug.Log("Can't move left");
                    return;
                }
                Debug.Log("Left");
            }
            if (_playerInput.Right)
            {
                if (!_sensors.CanMoveRight())
                {
                    Debug.Log("Can't move right");
                    return;
                }    
                Debug.Log("Right");
            }
            if (_playerInput.Up)
            {
                if (!_sensors.CanMoveForward())
                {
                    Debug.Log("Can't move forward");
                    return;
                }
                Debug.Log("Up");
            }
            if (_playerInput.Down)
            {
                if (!_sensors.CanMoveBackward())
                {
                    Debug.Log("Can't move backward");
                    return;
                }
                Debug.Log("Down");
            }
        }
    }
}