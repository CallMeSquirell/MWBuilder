using System.Collections.Generic;
using System.Linq;
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
            Model.OnGateSelectionChanged(_selectedGateView.NonNull() ? _selectedGateView.SpawnPoint : null);
        }

        private void OnPortalsRefreshRequired()
        {
            var pool = new List<PortalGateView>(_gates);

            for (int i = 0; i < _gates.Count; i += 2)
            {
                var firstItem = PickUpRandomItem(pool);
                var secondItem = PickUpRandomItem(pool);

                if (firstItem.NonNull() || secondItem.NonNull())
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

            var gate = pool[Random.Range(0, pool.Capacity)];
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