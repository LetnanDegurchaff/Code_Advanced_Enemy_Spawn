using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code_Advanced_Enemy_Spawn
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private int _speed;

        private IReadOnlyList<IReadOnlyTransform> _path;
        private Vector3 _target;
        private int _pathIndex;

        private void Update()
        {
            if (transform.position == _target)
                UpdateTarget();

            transform.position = Vector3.MoveTowards
                (transform.position, _target, _speed * Time.deltaTime);
        }

        private void UpdateTarget()
        {
            if (_pathIndex >= _path.Count - 1)
                _pathIndex = 0;
            else
                _pathIndex++;

            _target = _path[_pathIndex].Position;
        }

        public void Init(IReadOnlyList<IReadOnlyTransform> path)
        {
            _path = path;
            _target = _path.First().Position;
            transform.position = _target;
            _pathIndex = 0;
        }
    }
}