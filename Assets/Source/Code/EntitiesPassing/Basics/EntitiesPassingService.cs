using System;
using System.Collections.Generic;
using Code.Extensions;

namespace Code.EntitiesPassing
{
    public class EntitiesPassingService : IEntitiesPassingService
    {
        private Dictionary<string, object> _entities = new();
        
        public event Action<string, object> OnEntitySetEvent;
        public event Action<string, object> OnEntityRemovedEvent;
        
        public void Set(string key, object entity)
        {
            _entities[key] = entity;
            
            OnEntitySetEvent?.Invoke(key, entity);
        }

        public object Get(string key)
        {
            return _entities.GetValueOrDefault(key);
        }

        public void Remove(string key)
        {
            if (!_entities.ContainsKey(key)) 
                return;

            var entity = _entities[key];

            _entities.Remove(key);
            
            OnEntityRemovedEvent?.Invoke(key, entity);
        }
    }
}