using System.Collections.Generic;
using UnityEngine;

namespace MapGeneration
{
    public class CellManager
    {
        private static Dictionary<Vector2Int, Cell> cells = new Dictionary<Vector2Int, Cell>();

        internal static Dictionary<Vector2Int, Cell> Cells => cells;

        internal static Cell GetCell(Vector2Int cellPosition)
        {
            if (!cells.ContainsKey(cellPosition))
            {
                cells.Add(cellPosition, new Cell(cellPosition));
            }

            return cells[cellPosition];
        }

        public static List<int> GetOpenNeighbors(Vector2Int gridPosition)
        {
            List<int> openNeighbors = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                Cell iteratorCell = GetCell(gridPosition + GridAdditor.Get(gridPosition.x, i));
                if (iteratorCell.Open)
                {
                    openNeighbors.Add(i);
                }
            }

            return openNeighbors;
        }
    }
}