using UnityEngine;

namespace Code
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private TileList _tileList;
        
        private void Awake()
        {
            _tileList.Add(this);
        }

        private void OnDestroy()
        {
            _tileList.Remove(this);
        }
    }
}