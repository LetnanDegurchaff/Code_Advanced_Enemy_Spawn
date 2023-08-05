using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code_Advanced_Enemy_Spawn
{
    public class Path : MonoBehaviour, IReadOnlyPath
    {
        private List<Point> _pathPoints;

        private void Awake()
        {
            _pathPoints = GetComponentsInChildren<Point>().ToList();
        }

        public IReadOnlyList<IReadOnlyPoint> Points => _pathPoints;

        public IReadOnlyPoint GetNextTarget(IReadOnlyPoint point)
        {
            int pathIndex = 0;

            foreach (var pathPoint in _pathPoints)
            {
                if (pathPoint == point as Point)
                    break;

                pathIndex++;
            }

            if (pathIndex >= _pathPoints.Count - 1)
                pathIndex = 0;
            else
                pathIndex++;

            return _pathPoints[pathIndex];
        }
    }

    public interface IReadOnlyPath
    {
        public IReadOnlyList<IReadOnlyPoint> Points { get; }

        IReadOnlyPoint GetNextTarget(IReadOnlyPoint point);
    }
}