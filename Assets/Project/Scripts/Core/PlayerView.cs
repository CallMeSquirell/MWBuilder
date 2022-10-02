using Core.Framework;
using UnityEngine;
using Utils.Framework.Extensions;

namespace Project.Scripts.Core
{
    public class PlayerView : BaseView<PlayerModel>
    {
        private const string RunTrigger = "run";
        private const string IdleTrigger = "idle";
        
        [SerializeField] private float _maxSpeed = 2f;
        [SerializeField] private float _acceleration = 0.3f;
        [SerializeField] private float _rotationLerp = 0.5f;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _body;
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _particle;
        [SerializeField] private Transform _root;

        private float _currentSpeed;
        private bool _isRunning;
        
        protected override void OnSetModel()
        {
            Model.DirectionChanged += OnDirectionChanged;
            Model.Teleported += OnTeleported;
            _isRunning = false;
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
                _body.localRotation = Quaternion.Lerp(_body.localRotation, Quaternion.LookRotation(v3), _rotationLerp * Time.fixedDeltaTime);
            }
            
            if (_currentSpeed != 0 != _isRunning)
            {
                _isRunning = !_isRunning;
                _animator.SetTrigger(_isRunning ? RunTrigger : IdleTrigger);
            }

            _rigidbody.velocity = _body.forward * _currentSpeed;
        }

        protected override void OnUnsetModel()
        {
            Model.DirectionChanged -= OnDirectionChanged;
            Model.Teleported -= OnTeleported;
        }
    }
}