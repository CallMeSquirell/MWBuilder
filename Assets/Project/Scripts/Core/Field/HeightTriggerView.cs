﻿using System;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class HeightTriggerView : MonoBehaviour
    {
        public event Action<int> Triggered;
        
        [SerializeField] private Collider _collider;
        [SerializeField] private int _index;

        private void OnTriggerEnter(Collider other)
        {
            Triggered?.Invoke(_index);
        }
    }
}