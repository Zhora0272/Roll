using UnityEngine;

public class ColliderFitter : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Transform _toolPoint;
    
    private void Update()
    {
        transform.position = _toolPoint.position;
        var scale = Vector3.Distance(_toolPoint.position,
            _spawnPosition.position);


        transform.localScale = new Vector3(scale, scale, scale);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_toolPoint.position,5);
        Gizmos.DrawSphere(_spawnPosition.position,5);
    }
}
