using UnityEngine;

public class Point : MonoBehaviour, IReadOnlyPoint
{
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public Vector3 Position
    {
        get { return _transform.position; }
    }
}

public interface IReadOnlyPoint
{
    public Vector3 Position { get; }
}