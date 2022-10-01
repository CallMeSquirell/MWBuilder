using UnityEngine;

namespace Project.Scripts.Core.Cells.Factory
{
    public interface ICellViewFactory
    {
        FieldCellView Create(Transform container);
    }
}