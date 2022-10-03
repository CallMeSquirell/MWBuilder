using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class PortalGateView : MonoBehaviour
    {
        public event Action<PortalGateView> Selected;
        public event Action<PortalGateView> UnSelected;
        
        [SerializeField] private Collider _collider;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private PortalGateView _linkedPortalGate;
        [SerializeField] private bool _ignore;

        [SerializeField] private List<Material> _materials;

        public PortalGateView LinkedPortalGate => _linkedPortalGate;
        public Transform SpawnPoint => _spawnPoint;

        public bool Ignore => _ignore;

        public void Initialize(PortalGateView linkedPortalGate, int isFirst)
        {
            _linkedPortalGate = linkedPortalGate;
            _renderer.material = _materials[isFirst % _materials.Count];
        }

        private void OnTriggerEnter(Collider other)
        {
            Selected?.Invoke(this);
        }
        
        private void OnTriggerExit(Collider other)
        {
            UnSelected?.Invoke(this);
        }
    }
}