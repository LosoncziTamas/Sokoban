using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Entities
{
    [CreateAssetMenu]
    public class EntityPrefabs : ScriptableObject
    {
        public Entity _baseEntity;
        public Entity Wall;
        public GameObject Player;
        public GameObject Box;
        public GameObject Goal;
    }
}