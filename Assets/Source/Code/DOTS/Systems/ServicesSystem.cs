using System;
using System.Collections.Generic;
using Code.Other;
using Unity.Entities;

namespace Code.DOTS
{
    public partial class ServicesSystem : SystemBase
    {
        private Dictionary<Type, IService> _services = new();
        
        protected override void OnUpdate() { }

        public T Get<T>() where T : IService
        {
            return (T)_services.GetValueOrDefault(typeof(T));
        }

        public void Set<T>(T service) where T : IService
        {
            _services[service.GetType()] = service;
        }
    }
}