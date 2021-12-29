using UnityEngine;

namespace Code.GameInput
{
    public class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        
        private void Update()
        {
            _playerInput.Clear();
            if (Input.GetButtonDown("Horizontal"))
            {
                var horizontal =  Input.GetAxis("Horizontal");
                _playerInput.Left = horizontal < 0;
                _playerInput.Right = horizontal > 0;
            }
            if (Input.GetButtonDown("Vertical"))
            {
                var vertical =  Input.GetAxis("Vertical");
                _playerInput.Down = vertical < 0;
                _playerInput.Up = vertical > 0;
            }
        }
    }
}
