using System.Collections;
using Code.GameInput;
using UnityEngine;

namespace Code.Player
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed;
        public float threshold;
        
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private PlayerSensors _sensors;
        [SerializeField] private Rigidbody _rigidbody;

        private bool _moving;

        private IEnumerator Move(Vector3 targetPos)
        {
            _moving = true;
            transform.position = targetPos;
            _moving = false;
            yield break;
        }

        private void Update()
        {
            if (_moving)
            {
                return;
            }
            
            if (_playerInput.Left)
            {
                if (!_sensors.CanMoveLeft())
                {
                    Debug.Log("Can't move left");
                    return;
                }

                var targetPos = transform.position + Vector3.left;
                StartCoroutine(Move(targetPos));
            }
            if (_playerInput.Right)
            {
                if (!_sensors.CanMoveRight())
                {
                    Debug.Log("Can't move right");
                    return;
                }    
                var targetPos = transform.position + Vector3.right;
                StartCoroutine(Move(targetPos));            
            }
            if (_playerInput.Up)
            {
                if (!_sensors.CanMoveForward())
                {
                    Debug.Log("Can't move forward");
                    return;
                }
                var targetPos = transform.position + Vector3.forward;
                StartCoroutine(Move(targetPos));
            }
            if (_playerInput.Down)
            {
                if (!_sensors.CanMoveBackward())
                {
                    Debug.Log("Can't move backward");
                    return;
                }
                var targetPos = transform.position + Vector3.back;
                StartCoroutine(Move(targetPos));
            }
        }
    }
}