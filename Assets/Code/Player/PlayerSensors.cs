using System;
using Code.Common;
using UnityEngine;

namespace Code.Player
{
    public class PlayerSensors : MonoBehaviour
    {
        [SerializeField] private Sensor _leftSensor;
        [SerializeField] private Sensor _rightSensor;
        [SerializeField] private Sensor _forwardSensor;
        [SerializeField] private Sensor _backSensor;
        
        public bool CanMove(Direction direction)
        {
            return direction switch
            {
                Direction.Left => !_leftSensor.Blocked,
                Direction.Right => !_rightSensor.Blocked,
                Direction.Forward => !_forwardSensor.Blocked,
                Direction.Back => !_backSensor.Blocked,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }

        public GameObject GetMovableGameObject(Direction direction)
        {
            return direction switch
            {
                Direction.Left => _leftSensor.MovableGameObject,
                Direction.Right => _rightSensor.MovableGameObject,
                Direction.Forward => _forwardSensor.MovableGameObject,
                Direction.Back => _backSensor.MovableGameObject,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }
}