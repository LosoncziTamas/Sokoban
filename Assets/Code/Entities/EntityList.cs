using System.Collections.Generic;
using UnityEngine;

namespace Code.Entities
{
    [CreateAssetMenu]
    public class EntityList : ScriptableObject
    {
        [SerializeField] private List<Entity> _entities = new List<Entity>();
        
        public List<Entity> GetEntitiesByType(EntityType entityType)
        {
            var result = new List<Entity>();
            
            foreach (var entity in _entities)
            {
                if (entity.EntityType == entityType)
                {
                    result.Add(entity);
                }
            }

            return result;
        }

        public void Add(Entity entity)
        {
            Debug.Assert(!_entities.Contains(entity));
            _entities.Add(entity);
        }

        public void Remove(Entity entity)
        {
            var success = _entities.Remove(entity);
            Debug.Assert(success);
        }
    }
}