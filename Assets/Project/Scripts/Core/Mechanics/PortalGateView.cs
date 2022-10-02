using System;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class PortalGateView : MonoBehaviour
    {
        public event Action<PortalGateView> Selected;
        public event Action<PortalGateView> UnSelected;
        
        [SerializeField] private Collider _collider;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private GameObject _firstTypeView;
        [SerializeField] private GameObject _secondTypeView;

        public PortalGateView LinkedPortalGate { get; private set; }
        public Transform SpawnPoint => _spawnPoint;

        public void Initialize(PortalGateView linkedPortalGate, bool isFirst)
        {
            LinkedPortalGate = linkedPortalGate;
            _firstTypeView.SetActive(isFirst);
            _secondTypeView.SetActive(!isFirst);
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