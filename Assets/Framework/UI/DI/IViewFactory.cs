using System.Threading;
using Cysharp.Threading.Tasks;
using UI.Framework.Data;
using UI.Framework.Views.Impl;
using UnityEngine;

namespace UI.Framework.DI
{
    public interface IViewFactory
    {
        UniTask<TView> Create<TView>(IViewDefinition data, Transform parent = null,  CancellationToken cancellationToken = default)
            where TView : ScreenBaseView;
    }
}