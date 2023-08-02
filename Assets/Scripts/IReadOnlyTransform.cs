using UnityEngine;

namespace Code_Advanced_Enemy_Spawn
{
    public class IReadOnlyTransform
    {
        public Vector3 Position { get; private set; }
        public Quaternion Rotation { get; private set; }
        public Vector3 Scale { get; private set; }

        public IReadOnlyTransform(Transform transform)
        {
            Position = transform.position;
            Rotation = transform.rotation;
            Scale = transform.localScale;
        }
    }
}