using System;
using Code.Common;
using UnityEngine;

namespace Code
{
    public class Pushable : MonoBehaviour
    {
        public void Push(Direction to)
        {
            var offset = to switch
            {
                Direction.Left => Vector3.left,
                Direction.Right => Vector3.right,
                Direction.Forward => Vector3.forward,
                Direction.Back => Vector3.back,
                _ => throw new ArgumentOutOfRangeException(nameof(to), to, null)
            };

            transform.position += offset;
            Debug.Log("push dir" + offset);
        }
    }
}