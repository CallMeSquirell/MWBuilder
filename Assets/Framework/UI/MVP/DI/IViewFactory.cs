using System.Threading;
using Cysharp.Threading.Tasks;
using Framework.UI.Managers.Data;
using Framework.UI.MVP.Views.Impl;
using UnityEngine;

namespace Framework.UI.MVP.DI
{
    public interface IViewFactory
    {
        UniTask<TView> Create<TView>(IViewDefinition data, Transform parent = null,  CancellationToken cancellationToken = default)
            where TView : ScreenBaseView;
    }
}