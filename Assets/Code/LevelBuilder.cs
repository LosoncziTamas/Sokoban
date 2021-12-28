using System;
using UnityEngine;

namespace Code
{
    public class LevelBuilder : MonoBehaviour
    {
        [SerializeField] private Tile _tile;

        private void Awake()
        {
            Create();
        }

        private void Create()
        {
            var tile = Instantiate(_tile);
        }
    }
}
