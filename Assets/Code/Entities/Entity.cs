using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Entities
{
    public class Entity : MonoBehaviour
    {
        [FormerlySerializedAs("TileList")] [SerializeField] protected EntityList _entityList;

        public Vector3 Offset;
        public EntityType EntityType;
        
        private void Awake()
        {
            _entityList.Add(this);
        }

        private void OnDestroy()
        {
            _entityList.Remove(this);
        }
    }
}