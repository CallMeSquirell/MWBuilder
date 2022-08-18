using GameStateMachine.Framework;
using Project.Scripts.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Infrastructure
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
