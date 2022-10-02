using System.Collections.Generic;
using Framework.Timer;
using Utils.Framework.Property;

namespace Project.Scripts.Core.Services
{
    public interface IPlayerService
    {
        IBindableProperty<int> TimeLeft { get; }
        PlayerModel PlayerModel { get; }
        void Initialize(IReadOnlyList<PlayerView> players, IActionTimer actionTimer);
        void RunTimer();
        void StopTimer();
    }
}