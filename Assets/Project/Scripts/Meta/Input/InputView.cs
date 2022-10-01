using Core.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

namespace Project.Scripts.Meta.Input
{
    public class InputView : BaseView<InputModel>, IPointerDownHandler
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Collider _collider;

        public void OnPointerDown(PointerEventData eventData)
        {
            Model
        }
    }
}