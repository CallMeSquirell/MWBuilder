using System.Collections.Generic;
using Core.Framework;
using UnityEngine;
using Utils.Framework.Extensions;

namespace Project.Scripts.Core
{
    public class PortalsView : BaseView<PortalsModel>
    {
        [SerializeField] private List<PortalGateView> _gates;

        private PortalGateView _selectedGateView;

        protected override void OnSetModel()
        {
            Model.PortalsRefreshRequired += OnPortalsRefreshRequired;
            foreach (var gate in _gates)
            {
                gate.Selected += OnSelected;
                gate.UnSelected += OnUnselected;
            }

            OnPortalsRefreshRequired();
        }

        private void OnSelected(PortalGateView gate)
        {
            Select(gate);
        }

        private void OnUnselected(PortalGateView gate)
        {
            if (gate == _selectedGateView)
            {
                Select(null);
            }
        }

        private void Select(PortalGateView gate)
        {
            _selectedGateView = gate;
            if (!_selectedGateView.NonNull() || !_selectedGateView.LinkedPortalGate.NonNull())
            {
                Model.OnGateSelectionChanged(null);
            }
            else
            {
                Model.OnGateSelectionChanged(_selectedGateView.LinkedPortalGate.SpawnPoint);
            }
        }

        private void OnPortalsRefreshRequired()
        {
            var pool = new List<PortalGateView>(_gates);
            var count = pool.Count;

            while (pool.Count > 0)
            {
                var firstItem = PickUpRandomItem(pool);
                var secondItem = PickUpRandomItem(pool);
                
                if (!firstItem.NonNull() || !secondItem.NonNull())
                {
                    break;
                }

                firstItem.Initialize(secondItem, true);
                secondItem.Initialize(firstItem, false);
            }
        }

        private PortalGateView PickUpRandomItem(List<PortalGateView> pool)
        {
            if (pool.Count == 0)
            {
                return null;
            }

            var gate = pool[Random.Range(0, pool.Count)];
            pool.Remove(gate);
            return gate;
        }

        protected override void OnUnsetModel()
        {
            Model.PortalsRefreshRequired -= OnPortalsRefreshRequired;
            foreach (var gate in _gates)
            {
                gate.Selected -= OnSelected;
                gate.UnSelected -= OnUnselected;
            }
        }
    }
}