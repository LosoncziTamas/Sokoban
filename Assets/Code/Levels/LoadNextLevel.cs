using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Levels
{
    public class LoadNextLevel : MonoBehaviour
    {
        [SerializeField] private LevelBuilder _levelBuilder;

        private List<LevelLayoutData> _progression = new List<LevelLayoutData>();

        private LevelLayoutData _level01 = new LevelLayoutData
        {
            Raw = new []
            {
                '_','_','1','1','1','_','_',
                '_','_','1','o','1','_','_',
                '1','1','1','x','1','1','1',
                '1','o','x','s','x','o','1',
                '1','1','1','x','1','1','1',
                '_','_','1','o','1','_','_',
                '_','_','1','1','1','_','_'
            },
            DimX = 7,
            DimY = 7
        };
        
        private int _levelIdx;

        private void Awake()
        {
            _progression.Add(_level01);
            _progression.Add(_level01);
        }

        private void Start()
        {
            _levelBuilder.Create(_progression[0]);
        }

        [UsedImplicitly]
        public void OnLevelComplete()
        {
            _levelBuilder.Destroy();
            _levelIdx++;
            _levelBuilder.Create(_progression[_levelIdx]);
        }
    }
}