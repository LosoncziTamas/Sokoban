using UnityEngine;

namespace Code
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] protected TileList TileList;

        public Vector3 Offset;
        
        private void Awake()
        {
            TileList.Add(this);
        }

        private void OnDestroy()
        {
            TileList.Remove(this);
        }
    }
}