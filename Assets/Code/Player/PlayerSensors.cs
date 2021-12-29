using UnityEngine;

namespace Code.Player
{
    public class PlayerSensors : MonoBehaviour
    {
        [SerializeField] private Sensor _leftSensor;
        [SerializeField] private Sensor _rightSensor;
        [SerializeField] private Sensor _forwardSensor;
        [SerializeField] private Sensor _backSensor;

        public bool CanMoveLeft() => !_leftSensor.Colliding;

        public bool CanMoveRight() => !_rightSensor.Colliding;

        public bool CanMoveForward() => !_forwardSensor.Colliding;
        
        public bool CanMoveBackward() => !_backSensor.Colliding;
    }
}