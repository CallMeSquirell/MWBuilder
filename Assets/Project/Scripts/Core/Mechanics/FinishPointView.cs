using System;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class FinishPointView : MonoBehaviour
    {
        public event Action<PlayerView> Finished;
        
        private void OnTriggerEnter(Collider other)
        {
            var component = other.GetComponentInParent<PlayerView>();
            Finished?.Invoke(component);
            gameObject.SetActive(false);
        }
    }
}