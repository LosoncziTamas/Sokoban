using Code.GameInput;
using UnityEngine;

namespace Code.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;

        private void Update()
        {
            if (_playerInput.Left)
            {
                Debug.Log("Left");
            }
            if (_playerInput.Right)
            {
                Debug.Log("Right");
            }
            if (_playerInput.Up)
            {
                Debug.Log("Up");
            }
            if (_playerInput.Down)
            {
                Debug.Log("Down");
            }
        }
    }
}