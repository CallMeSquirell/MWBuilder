using GameStateMachine.Framework.GameStateMachine;
using Project.Scripts.Core;
using Project.Scripts.Game.Impl;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Game
{
   public class Bootstrapper : MonoBehaviour
   {
      private IGameStateMachine _gameStateMachine;

      [Inject]
      public void Inject(IGameStateMachine gameStateMachine)
      {
         _gameStateMachine = gameStateMachine;
      }

      private void Start()
      {
         _gameStateMachine.Enter<BootstrapState>();
      }
   }
}
