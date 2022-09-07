using Core.Framework;

namespace Project.Scripts.Core.Cells
{
    public class FieldCellView : BaseView<FieldCellData>
    {
        private const string NameFormat = "Cell[{0},{1}]";
        
        protected override void OnDataSetUpped()
        {
            name = string.Format(NameFormat, Data.Position.x, Data.Position.y);
        }
    }
}