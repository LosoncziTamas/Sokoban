using Code.Entities;
using UnityEngine;

namespace Code.Levels
{
    public class LevelBuilder : MonoBehaviour
    {
        [SerializeField] private EntityPrefabs _entityPrefabs;
        
        public void Create(LevelLayoutData layoutData)
        {
            var dimX = layoutData.DimX;
            var dimY = layoutData.DimY;
            var sourceData = layoutData.Raw;
            var offset = 1.0f;
            var spawnStart = (Vector3.left * dimX * 0.5f) + (Vector3.back * dimY * 0.5f);
            for (var y = dimY - 1; y >= 0; y--)
            {
                for (var x = 0; x < dimX; x++)
                {
                    var levelData = sourceData[y * dimY + x];
                    var spawnPos = spawnStart + new Vector3(x, 0, y);
                    switch (levelData)
                    {
                        case '_':
                            break;
                        case 'x':
                        {
                            var tile = Instantiate(_entityPrefabs._baseEntity, transform);
                            tile.name = $"Box Tile x: {x} y: {y}";
                            tile.transform.localPosition = spawnPos + tile.Offset;
                            
                            var box = Instantiate(_entityPrefabs.Box, transform);
                            var boxOffset = Vector3.up * 0.1f;
                            box.transform.localPosition = spawnPos + boxOffset;
                            break;
                        }
                        case 'o':
                        {
                            var tile = Instantiate(_entityPrefabs._baseEntity, transform);
                            tile.name = $"Goal Tile x: {x} y: {y}";
                            tile.transform.localPosition = spawnPos + tile.Offset;
                            
                            var goal = Instantiate(_entityPrefabs.Goal, transform);
                            var goalOffset = Vector3.up * 0.1f;
                            goal.transform.localPosition = spawnPos + goalOffset;
                            break;
                        }
                        case 's':
                        {
                            var tile = Instantiate(_entityPrefabs._baseEntity, transform);
                            tile.name = $"Start Tile x: {x} y: {y}";
                            tile.transform.localPosition = spawnPos + tile.Offset;
                            
                            var player = Instantiate(_entityPrefabs.Player, transform);
                            var playerOffset = Vector3.up * 0.7f;
                            player.transform.localPosition = spawnPos + playerOffset;
                            break;
                        }
                        case '1':
                        {
                            var tile = Instantiate(_entityPrefabs.Wall, transform);
                            tile.name = $"Wall x: {x} y: {y}";
                            tile.transform.localPosition = spawnPos + tile.Offset;
                            break;
                        }
                        default:
                        {
                            var tile = Instantiate(_entityPrefabs._baseEntity, transform);
                            tile.name = $"Base Tile x: {x} y: {y}";
                            tile.transform.localPosition = spawnPos + tile.Offset;
                            break;
                        }
                    }
                }
            }
        }

        public void Destroy()
        {
            var childCount = transform.childCount;
            for (var i = 0; i < childCount; ++i)
            {
                var child = transform.GetChild(i);
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
