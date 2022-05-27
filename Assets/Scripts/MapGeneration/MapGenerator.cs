using System;
using System.Collections.Generic;
using UnityEngine;

namespace MapGeneration
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject straightPathCellPrefab;
        [SerializeField] private GameObject startPathCellPrefab;
        [SerializeField] private GameObject endPathCellPrefab;
        [SerializeField] private GameObject leftCurvedPathCellPrefab;
        [SerializeField] private GameObject rightCurvedPathCellPrefab;
        [SerializeField] private GameObject closedCellPrefab;
        [SerializeField] private GameObject towerPrefab;

        [SerializeField] private MapInfo_SO mapInfo;
        
        private Cell currentCell;
        private int towerAmount;
        
        private void Awake()
        {
            Generate();
        }

        public void Generate()
        {
            currentCell = CellManager.GetCell(new Vector2Int(0, 0));
            mapInfo.Path.Add(currentCell.WorldPosition);
            for (int i = 0; i < 10; i++)
            {
                currentCell = currentCell.GetRandomNext();
                mapInfo.Path.Add(currentCell.WorldPosition);
            }

            foreach (Cell cell in CellManager.Cells.Values)
            {
                GameObject tile;
                switch (cell.PathInfo.GetType())
                {
                    case PathInfo.Type.NONE:
                        if (cell.CloseCount > 1)
                        {
                            tile = Instantiate(towerPrefab, transform);
                        }
                        else
                        {
                            tile = Instantiate(closedCellPrefab, transform);
                        }
                        
                        break;
                    case PathInfo.Type.START:
                        tile = Instantiate(startPathCellPrefab, transform);
                        tile.transform.Rotate(Vector3.up, (6-cell.PathInfo.exitPoint) * 60);
                        break;
                    case PathInfo.Type.STRAIGHT:
                        tile = Instantiate(straightPathCellPrefab, transform);
                        tile.transform.Rotate(Vector3.up, (6-cell.PathInfo.entryPoint) * 60);
                        break;
                    case PathInfo.Type.LEFTCURVED:
                        tile = Instantiate(leftCurvedPathCellPrefab, transform);
                        tile.transform.Rotate(Vector3.up, (6-cell.PathInfo.entryPoint) * 60);
                        break;
                    case PathInfo.Type.RIGHTCURVED:
                        tile = Instantiate(rightCurvedPathCellPrefab, transform);
                        tile.transform.Rotate(Vector3.up, (6-cell.PathInfo.entryPoint) * 60);
                        break;
                    case PathInfo.Type.END:
                        tile = Instantiate(endPathCellPrefab, transform);
                        tile.transform.Rotate(Vector3.up, (6-cell.PathInfo.entryPoint) * 60);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                tile.transform.localPosition = new Vector3(cell.WorldPosition.x, 0, cell.WorldPosition.y);
            }
        }
    }
}