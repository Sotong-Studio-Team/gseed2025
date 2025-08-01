using UnityEngine;

public class GridForBomb : MonoBehaviour
{
    [SerializeField] private float _size = 1f;
    [SerializeField] private int _minPos = 0;
    [SerializeField] private int _maxPos = 40;

    public float Size { get { return _size; } }

    public Vector2 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / _size);
        int yCount = Mathf.RoundToInt(position.y / _size);

        Vector3 result = new Vector2(
            (float)xCount * _size,
            (float)yCount * _size);

        result += transform.position;

        return result;
    }

    private void OnDrawGizmos()
    {
        for(float x = _minPos; x < _maxPos; x += _size)
        {
            for(float y = _minPos; y < _maxPos; y += _size)
            {
                var point = GetNearestPointOnGrid(new Vector2(x, y));
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }
}
