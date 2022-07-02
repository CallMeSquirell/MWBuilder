using Project.Scripts.Game.Impl;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Game
{
   public class Bootstrapper : MonoBehaviour, IInitializable
   {
      private IGameStateMachine _gameStateMachine;

      [Inject]
      public void Inject(IGameStateMachine gameStateMachine)
      {
         _gameStateMachine = gameStateMachine;
      }

      public void Initialize()
      {
         _gameStateMachine.Enter<BootstrapState>();
      }
   }
}
