using System.Collections;
using Code.Common;
using Code.Entities;
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
        [SerializeField] private Console _console;
        [SerializeField] private EntityList _entityList;
        [SerializeField] private GameEvent _levelCompletionEvent;
        
        private bool _moving;

        private IEnumerator Move(Vector3 targetPos)
        {
            _moving = true;
            transform.position = targetPos;
            _moving = false;
            yield return new WaitForFixedUpdate();
            CheckCompletion();
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
                    _console.Send("Can't move left");
                    return;
                }

                BeginMove(Direction.Left, transform.position + Vector3.left);
            }
            if (_playerInput.Right)
            {
                if (!_sensors.CanMove(Direction.Right))
                {
                    _console.Send("Can't move right");
                    return;
                }    
                
                BeginMove(Direction.Right, transform.position + Vector3.right);

            }
            if (_playerInput.Up)
            {
                if (!_sensors.CanMove(Direction.Forward))
                {
                    _console.Send("Can't move forward");
                    return;
                }
                BeginMove(Direction.Forward, transform.position + Vector3.forward);

            }
            if (_playerInput.Down)
            {
                if (!_sensors.CanMove(Direction.Back))
                {
                    _console.Send("Can't move backward");
                    return;
                }
                BeginMove(Direction.Back, transform.position + Vector3.back);
            }
        }

        private void CheckCompletion()
        {
            var goals = _entityList.GetEntitiesByType(EntityType.Goal);
            var completedGoalCount = 0;
            
            foreach (var goal in goals)
            {
                var sensor = goal.GetComponent<Sensor>();
                if (sensor && sensor.MovableGameObject)
                {
                    completedGoalCount++;
                }
            }

            if (completedGoalCount == goals.Count)
            {
                _levelCompletionEvent.Raise();
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