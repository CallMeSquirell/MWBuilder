using UnityEngine;
using Utils.Framework.Extensions;
using Utils.Framework.Pool;

namespace Utils.Framework.UI.Lable
{
    [RequireComponent(typeof(RectTransform))]
    public class LeadingLabele : ObjectPoolItem
    {
        [SerializeField] private Vector3 _offset = new Vector3(0,5, 0);
        private Transform _target;
        private Camera _camera;
        protected RectTransform SelfTransform { get; private set; }

        private void Awake()
        {
            SelfTransform = GetComponent<RectTransform>();
            _camera = Camera.main;
        }

        public void SetUpTarget(Transform target)
        {
            _target = target;
        }

        private void Update()
        {
            if (_target.NonNull())
            {
                SelfTransform.position = _camera.WorldToScreenPoint(_target.position) + _offset;
            }
        }
    }
}