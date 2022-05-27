using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

namespace MapGeneration
{
    public class Cell
    {
        private Vector2Int gridPosition;
        private Vector2 worldPosition;
        private bool open = true;
        private PathInfo pathInfo = new PathInfo();
        private int closeCount;

        public static float worldPositionMultiplier = (float) (1.5 * 5 / Math.Sqrt(3));

        public Cell(Vector2Int gridPosition)
        {
            this.gridPosition = gridPosition;
            this.worldPosition = new Vector2(gridPosition.x * worldPositionMultiplier,
                gridPosition.y * 5f + 2.5f * (Math.Abs(gridPosition.x) % 2));
        }

        public Vector2Int GridPosition => gridPosition;

        public Vector2 WorldPosition => worldPosition;

        public bool Open => open;

        public PathInfo PathInfo => pathInfo;

        public int CloseCount => closeCount;

        public void CloseCell()
        {
            this.open = false;
            closeCount++;
        }

        public Cell GetRandomNext()
        {
            List<int> openNeighbors = CellManager.GetOpenNeighbors(gridPosition);
            int random = openNeighbors[Random.Range(0, openNeighbors.Count)];
            Cell randomCell = CellManager.GetCell(gridPosition + GridAdditor.Get(gridPosition.x, random));
            randomCell.PathInfo.entryPoint = (3+random)%6;
            CellManager.GetCell(gridPosition + GridAdditor.Get(gridPosition.x, random - 1)).CloseCell();
            CellManager.GetCell(gridPosition + GridAdditor.Get(gridPosition.x, random + 1)).CloseCell();
            CloseCell();
            pathInfo.exitPoint = random;
            return randomCell;
        }
    }
}