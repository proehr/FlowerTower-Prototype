using System;
using MapGeneration;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private MapInfo_SO mapInfo;

        private int currentTargetIterator;
        private Vector3 currentTarget;

        private void Start()
        {
            transform.position = new Vector3(mapInfo.Path[mapInfo.Path.Count - 1].x, 0,
                mapInfo.Path[mapInfo.Path.Count - 1].y);
            currentTargetIterator = mapInfo.Path.Count - 2;
            currentTarget = new Vector3(mapInfo.Path[currentTargetIterator].x, 0,
                mapInfo.Path[currentTargetIterator].y);
        }

        private void Update()
        {
            float step = Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);
            if (Vector3.Distance(transform.position, currentTarget) < 1.5 && currentTargetIterator > 1)
            {
                currentTargetIterator--;
                currentTarget = new Vector3(mapInfo.Path[currentTargetIterator].x, 0,
                    mapInfo.Path[currentTargetIterator].y);
            }
        }
    }
}