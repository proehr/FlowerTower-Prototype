using System;
using System.Collections.Generic;
using UnityEngine;

namespace MapGeneration
{
    public class PathInfo
    {
        public enum Type
        {
            NONE,
            START,
            STRAIGHT,
            LEFTCURVED,
            RIGHTCURVED,
            END
        }

        private static List<Vector2Int> leftCurves = new List<Vector2Int>();
        private static List<Vector2Int> rightCurves = new List<Vector2Int>();

        static PathInfo()
        {
            leftCurves.Add(new Vector2Int(0,2));
            leftCurves.Add(new Vector2Int(1,3));
            leftCurves.Add(new Vector2Int(2,4));
            leftCurves.Add(new Vector2Int(3,5));
            leftCurves.Add(new Vector2Int(4,0));
            leftCurves.Add(new Vector2Int(5,1));
            
            rightCurves.Add(new Vector2Int(0,4));
            rightCurves.Add(new Vector2Int(1,5));
            rightCurves.Add(new Vector2Int(2,0));
            rightCurves.Add(new Vector2Int(3,1));
            rightCurves.Add(new Vector2Int(4,2));
            rightCurves.Add(new Vector2Int(5,3));
        }

        public int entryPoint = -1;
        public int exitPoint = -1;

        internal Type GetType()
        {
            if (entryPoint < 0 && exitPoint < 0)
            {
                return Type.NONE;
            }
            
            if (entryPoint < 0)
            {
                return Type.START;
            }

            if (exitPoint < 0)
            {
                return Type.END;
            }

            if (Math.Abs(exitPoint - entryPoint) == 3)
            {
                return Type.STRAIGHT;
            }

            if (leftCurves.Contains(new Vector2Int(entryPoint, exitPoint)))
            {
                return Type.LEFTCURVED;
            }

            return Type.RIGHTCURVED;
        }
    }
}