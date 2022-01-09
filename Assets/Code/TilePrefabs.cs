using UnityEngine;

namespace Code
{
    [CreateAssetMenu]
    public class TilePrefabs : ScriptableObject
    {
        public Tile BaseTile;
        public Tile Wall;
        public GameObject Player;
        public GameObject Box;
        public GameObject Goal;
    }
}