using System.Collections.Generic;
using Utils.Framework.Property;

namespace Project.Scripts.Core.Services
{
    public interface IPlayerService
    {
        IBindableProperty<int> TimeLeft { get; }
        PlayerModel PlayerModel { get; }
        void Initialize(IReadOnlyList<PlayerView> players);
        void RunTimer();
        void StopTimer();
    }
}