using System.Linq;
using UnityEngine;

namespace Code_Advanced_Enemy_Spawn
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private int _speed;

        private IReadOnlyPath _path;
        private IReadOnlyPoint _target;

        private void Update()
        {
            if (transform.position == _target.Position)
                _target = _path.GetNextTarget(_target);

            transform.position = Vector3.MoveTowards
                (transform.position, _target.Position, _speed * Time.deltaTime);
        }

        public void Init(IReadOnlyPath path)
        {
            _path = path;
            _target = _path.Points.First();
            transform.position = _target.Position;
        }
    }
}