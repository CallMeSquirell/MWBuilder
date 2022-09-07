using System;
using Project.Scripts.Core.Cells.Mechanics;
using Project.Scripts.Core.Configs;
using Project.Scripts.Core.Hand;
using Project.Scripts.Core.Input;
using Project.Scripts.Core.Processors;

namespace Project.Scripts.Core
{
    public class LevelModel : IDisposable
    {
        private readonly CardProcessorManager _cardProcessorManager;
        
        public FieldData FieldData { get; }
        public HandModel HandModel { get; }
        public FieldInputModel FieldInputModel { get; }

        public LevelModel()
        {
            FieldData = new FieldData();
            HandModel = new HandModel();
            FieldInputModel = new FieldInputModel();
            _cardProcessorManager = new CardProcessorManager();
        }
        
        public void Initialize(LevelConfig config)
        {
            FieldData.Initialize(config.FieldSize);
            
            AddProcessors();
            
            HandModel.CardSelected += OnCardSelected;
        }

        private void AddProcessors()
        {
            _cardProcessorManager.AddProcessor(new TakeTakeProcessor());
        }
        
        private void OnCardSelected(ICard card)
        {
            _cardProcessorManager.Use(card);
        }
        
        public void Dispose()
        {
            HandModel.CardSelected -= OnCardSelected;
        }
    }
}