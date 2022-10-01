using System;
using Core.Framework;
using DG.Tweening;
using UnityEngine;
using Utils.Framework.Extensions;

namespace Project.Scripts.Core
{
    public class PlayerView : BaseView<PlayerModel>
    {
        [SerializeField] private float _maxSpeed = 2f;
        [SerializeField] private float _acceleration = 0.3f;
        [SerializeField] private float _rotationLerp = 0.5f;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _body;
        [SerializeField] private Transform _root;

        private float _currentSpeed;
        private Transform _transform;
        private void Awake()
        {
            _transform = transform;
        }

        protected override void OnSetModel()
        {
            Model.DirectionChanged += OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector2 dir)
        {
            var v3 = dir.ToXZVector3();
            if (dir == Vector2.zero )
            {
                _currentSpeed = 0;
            }
            else
            {
                _currentSpeed = Mathf.Clamp(_currentSpeed + _acceleration, 0, _maxSpeed);
                _body.localRotation = Quaternion.Lerp(_body.localRotation, Quaternion.LookRotation(v3), _rotationLerp * Time.fixedDeltaTime);
            }

            _rigidbody.velocity = _body.forward * _currentSpeed;
        }

        protected override void OnUnsetModel()
        {
            Model.DirectionChanged -= OnDirectionChanged;
        }
    }
}