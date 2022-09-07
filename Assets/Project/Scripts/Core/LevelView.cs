using Core.Framework;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class LevelView : BaseView<LevelModel>
    {
        public const string Key = nameof(LevelView);
        
        [SerializeField] private FieldView _fieldView;

        protected override void OnDataSetUpped()
        {
            _fieldView.Data = Data.FieldData;
        }

        protected override void OnDataRemoved()
        {
            
        }
    }
}