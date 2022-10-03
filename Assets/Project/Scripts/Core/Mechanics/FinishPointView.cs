using System;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class FinishPointView : MonoBehaviour
    {
        public event Action<PlayerView> Finished;

        [SerializeField] private PlayerView _requiredPlayer;

        private void OnTriggerEnter(Collider other)
        {
            var component = other.GetComponentInParent<PlayerView>();
            if (component == _requiredPlayer)
            {
                Finished?.Invoke(component);
                gameObject.SetActive(false);
            }
        }
    }
}