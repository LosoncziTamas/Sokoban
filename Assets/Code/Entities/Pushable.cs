using System;
using Code.Common;
using Code.Player;
using UnityEngine;

namespace Code.Entities
{
    public class Pushable : MonoBehaviour
    {
        [SerializeField] private DirectionalSensors _sensors;
        
        public bool Push(Direction to)
        {
            if (!CanMoveToDirection(to))
            {
                return false;
            }
            
            var offset = to switch
            {
                Direction.Left => Vector3.left,
                Direction.Right => Vector3.right,
                Direction.Forward => Vector3.forward,
                Direction.Back => Vector3.back,
                _ => throw new ArgumentOutOfRangeException(nameof(to), to, null)
            };

            transform.position += offset;

            return true;
        }

        private bool CanMoveToDirection(Direction to)
        {
            return to == Direction.Back && _sensors.CanMove(Direction.Back) || 
                   to == Direction.Forward && _sensors.CanMove(Direction.Forward) || 
                   to == Direction.Left && _sensors.CanMove(Direction.Left) || 
                   to == Direction.Right && _sensors.CanMove(Direction.Right);
        }
        
    }
}