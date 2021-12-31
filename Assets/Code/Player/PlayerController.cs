using System.Collections;
using Code.Common;
using Code.GameInput;
using UnityEngine;

namespace Code.Player
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed;
        public float threshold;
        
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private DirectionalSensors _sensors;
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
                if (!_sensors.CanMove(Direction.Left))
                {
                    Debug.Log("Can't move left");
                    return;
                }

                BeginMove(Direction.Left, transform.position + Vector3.left);
            }
            if (_playerInput.Right)
            {
                if (!_sensors.CanMove(Direction.Right))
                {
                    Debug.Log("Can't move right");
                    return;
                }    
                
                BeginMove(Direction.Right, transform.position + Vector3.right);

            }
            if (_playerInput.Up)
            {
                if (!_sensors.CanMove(Direction.Forward))
                {
                    Debug.Log("Can't move forward");
                    return;
                }
                BeginMove(Direction.Forward, transform.position + Vector3.forward);

            }
            if (_playerInput.Down)
            {
                if (!_sensors.CanMove(Direction.Back))
                {
                    Debug.Log("Can't move backward");
                    return;
                }
                BeginMove(Direction.Back, transform.position + Vector3.back);
            }
        }

        private void BeginMove(Direction direction, Vector3 targetPos)
        {
            var movable = _sensors.GetMovableGameObject(direction);
            var successfulPush = true; 
            
            if (movable != null)
            {
                var pushable = movable.GetComponent<Pushable>();
                if (pushable != null)
                {
                    successfulPush = pushable.Push(direction);
                }
            }
            
            if (successfulPush)
            {
                StartCoroutine(Move(targetPos));
            }
        }
    }
}