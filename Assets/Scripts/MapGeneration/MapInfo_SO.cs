using System.Collections.Generic;
using UnityEngine;

namespace MapGeneration
{
    [CreateAssetMenu(fileName = "MapInfo", menuName = "MapGeneration/MapInfo", order = 0)]
    public class MapInfo_SO : ScriptableObject
    {
        private List<Vector2> path = new List<Vector2>();

        public List<Vector2> Path => path;
    }
}