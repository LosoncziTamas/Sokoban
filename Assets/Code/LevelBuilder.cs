using UnityEngine;

namespace Code
{
    public class LevelBuilder : MonoBehaviour
    {
        private const int DimX = 7;
        private const int DimY = 7;
        
        [SerializeField] private TilePrefabs _tilePrefabs;

        private char[] _level = 
        {
            '_','_','1','1','1','_','_',
            '_','_','1','0','1','_','_',
            '1','1','1','o','1','1','1',
            '1','o','x','0','x','o','1',
            '1','1','1','x','1','1','1',
            '_','_','1','o','1','_','_',
            '_','_','1','1','1','_','_'
        };

        private void Awake()
        {
            Create();
        }

        private void Create()
        {
            var offset = 1.0f;
            var spawnStart = (Vector3.left * DimX * 0.5f) + (Vector3.back * DimY * 0.5f);
            for (var y = DimY - 1; y >= 0; y--)
            {
                for (var x = 0; x < DimX; x++)
                {
                    var levelData = _level[y * DimY + x];
                    var spawnPos = spawnStart + new Vector3(x, 0, y);
                    switch (levelData)
                    {
                        case '_':
                            break;
                        case '1':
                        {
                            var tile = Instantiate(_tilePrefabs.Wall, transform);
                            tile.transform.localPosition = spawnPos;
                            break;
                        }
                        default:
                        {
                            var tile = Instantiate(_tilePrefabs.BaseTile, transform);
                            tile.transform.localPosition = spawnPos;
                            break;
                        }
                    }
                }
            }
        }
    }
}
