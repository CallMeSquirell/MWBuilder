using System;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _lerpSpeed;

        private Vector3 _deltaPosition;
        private Transform _transform;
        
        private void Awake()
        {
            _transform = transform;
            _deltaPosition = _transform.position - _target.position;
        }

        private void FixedUpdate()
        {
            var position = _transform.position;
            position = Vector3.Lerp(position, _target.position + _deltaPosition, _lerpSpeed * Time.fixedDeltaTime);
            _transform.position = position;
        }
    }
}