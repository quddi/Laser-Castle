﻿using Code.EntitiesPassing;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
// ReSharper disable LocalVariableHidesMember

namespace Code.Gameplay
{
    public class CanvasCameraGetter : MonoBehaviour
    {
        [SerializeField, TabGroup("Parameters")] private string _cameraKey;
        
        [SerializeField, TabGroup("Components")] private Canvas _canvas;
        
        private IEntitiesPassingService _entitiesPassingService;

        [Inject]
        private void Construct(IEntitiesPassingService entitiesPassingService)
        {
            _entitiesPassingService = entitiesPassingService;
            
            OnCameraChangedHandler(_cameraKey, _entitiesPassingService.Get(_cameraKey));

            _entitiesPassingService.OnEntitySetEvent += OnCameraChangedHandler;
        }

        private void OnCameraChangedHandler(string key, object newCamera)
        {
            if (key != _cameraKey || newCamera is not Camera camera) 
                return;

            _canvas.worldCamera = camera;
        }

        private void OnDestroy()
        {
            if (_entitiesPassingService != null)
                _entitiesPassingService.OnEntitySetEvent -= OnCameraChangedHandler;
        }
    }
}