using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    [CreateAssetMenu]
    public class TileList : ScriptableObject
    {
        [SerializeField] private List<Tile> _tiles = new List<Tile>();
        
        public void GetNearestTile(Vector3 to)
        {
            
        }

        public void Add(Tile tile)
        {
            Debug.Assert(!_tiles.Contains(tile));
            _tiles.Add(tile);
        }

        public void Remove(Tile tile)
        {
            var success = _tiles.Remove(tile);
            Debug.Assert(success);
        }
    }
}