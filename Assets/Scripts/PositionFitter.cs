using UnityEngine;

public class PositionFitter : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        transform.localPosition = 
            (new Vector3(transform.localPosition.x,

            Vector3.Distance(transform.position,
            _spawnPosition.position),

            -Vector3.Distance(transform.position,
            _spawnPosition.position) / 2) - _offset);
    }
}
