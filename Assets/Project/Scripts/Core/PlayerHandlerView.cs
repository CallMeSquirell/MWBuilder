using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class PlayerHandlerView : MonoBehaviour
    {
        [SerializeField] private List<PlayerView> _players;

        public List<PlayerView> Players => _players;
    }
}