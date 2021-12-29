using UnityEngine;

namespace Code.GameInput
{
    [CreateAssetMenu]
    public class PlayerInput : ScriptableObject
    {
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }

        public void Clear()
        {
            Left = Down = Right = Up = false;
        }
    }
}