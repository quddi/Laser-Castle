using System;

namespace Code.EntitiesPassing
{
    public interface IEntitiesPassingService
    {
        public event Action<string, object> OnEntitySetEvent;
        public event Action<string, object> OnEntityRemovedEvent;
        
        public void Set(string key, object entity);

        public object Get(string key);

        public void Remove(string key);
    }
}