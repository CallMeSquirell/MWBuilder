using System.Collections.Generic;
using Utils.Framework.Property;

namespace Project.Scripts.Core.Services
{
    public interface IPlayerChangeService
    {
        IBindableProperty<int> TimeLeft { get; }
        void Initialize(IReadOnlyList<PlayerView> players);
        void Run();
        void Stop();
    }
}