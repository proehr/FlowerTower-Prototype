using System;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

namespace MapGeneration
{
    public class GridAdditor
    {
        public static Vector2Int[] gridAdditorsTop = new Vector2Int[6];
        public static Vector2Int[] gridAdditorsBottom = new Vector2Int[6];

        static GridAdditor()
        {
            gridAdditorsTop[0] = new Vector2Int(0, -1);
            gridAdditorsTop[1] = new Vector2Int(1, -1);
            gridAdditorsTop[2] = new Vector2Int(1, 0);
            gridAdditorsTop[3] = new Vector2Int(0, 1);
            gridAdditorsTop[4] = new Vector2Int(-1, 0);
            gridAdditorsTop[5] = new Vector2Int(-1, -1);
            
            gridAdditorsBottom[0] = new Vector2Int(0, -1);
            gridAdditorsBottom[1] = new Vector2Int(1, 0);
            gridAdditorsBottom[2] = new Vector2Int(1, 1);
            gridAdditorsBottom[3] = new Vector2Int(0, 1);
            gridAdditorsBottom[4] = new Vector2Int(-1, 1);
            gridAdditorsBottom[5] = new Vector2Int(-1, 0);
        }

        internal static Vector2Int Get(int column, int i)
        {
            if (i < 0)
            {
                i += 6;
            }
            else if (i >= 6)
            {
                i -= 6;
            }

            if (Math.Abs(column) % 2 == 0)
            {
                return gridAdditorsTop[i];
            }
            else
            {
                return gridAdditorsBottom[i];
            }
            
        }
    }
}