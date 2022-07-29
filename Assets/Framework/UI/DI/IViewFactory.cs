using System.Threading;
using Cysharp.Threading.Tasks;
using UI.Framework.UI.Data;
using UI.Framework.UI.Views.Impl;
using UnityEngine;

namespace UI.Framework.UI.DI
{
    public interface IViewFactory
    {
        UniTask<TView> Create<TView>(IViewDefinition data, Transform parent = null,  CancellationToken cancellationToken = default)
            where TView : ScreenBaseView;
    }
}