using System;
using System.Collections.Generic;
using Core.Framework;
using UnityEngine;
using Utils.Framework.Extensions;

namespace Project.Scripts.Core
{
    public class PlayerView : BaseView<PlayerModel>
    {
        private const string RunTrigger = "run";
        private const string PushTrigger = "push";

        [SerializeField] private float _maxSpeed = 2f;
        [SerializeField] private float _acceleration = 0.3f;
        [SerializeField] private float _rotationLerp = 0.5f;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _body;
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _particle;
        [SerializeField] private Transform _root;
        [SerializeField] private PlayerCubeCollisionDetector _collisionDetector;

        private float _currentSpeed;
      
        private List<DraggingCubeView> _collidedCubes = new();

        protected override void OnSetModel()
        {
            Model.DirectionChanged += OnDirectionChanged;
            Model.Teleported += OnTeleported;
            _collisionDetector.Changed += OnChanged;
        }

        private void OnChanged(bool value)
        {
            _animator.SetBool(PushTrigger, value);
        }

        private void OnTeleported(Vector3 pos)
        {
            _particle.gameObject.SetActive(false);
            _root.position = pos;
            _particle.gameObject.SetActive(true);
        }

        private void OnDirectionChanged(Vector2 dir)
        {
            var v3 = dir.ToXZVector3();
            if (dir == Vector2.zero)
            {
                _currentSpeed = 0;
            }
            else
            {
                _currentSpeed = Mathf.Clamp(_currentSpeed + _acceleration, 0, _maxSpeed);
                _body.localRotation = Quaternion.Lerp(_body.localRotation, Quaternion.LookRotation(v3),
                    _rotationLerp * Time.fixedDeltaTime);
            }

            _animator.SetBool(RunTrigger, _currentSpeed != 0);

            _rigidbody.velocity = _body.forward * _currentSpeed;
        }

        private void OnCollisionEnter(Collision collisionInfo)
        {
            if (collisionInfo.gameObject.TryGetComponent(out DraggingCubeView cubeView) && !_collidedCubes.Contains(cubeView))
            {
                _collidedCubes.Add(cubeView);
                _animator.SetBool(PushTrigger, true);
            }
        }
        
        private void OnCollisionExit(Collision collisionInfo)
        {
            if (collisionInfo.gameObject.TryGetComponent(out DraggingCubeView cubeView))
            {
                _collidedCubes.Remove(cubeView);
                _animator.SetBool(PushTrigger, _collidedCubes.Count != 0 );
            }
        }

        protected override void OnUnsetModel()
        {
            Model.DirectionChanged -= OnDirectionChanged;
            Model.Teleported -= OnTeleported;
            _collisionDetector.Changed -= OnChanged;
        }
    }
}