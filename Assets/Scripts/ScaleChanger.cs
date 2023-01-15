using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 scaleChangeDirection;

    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }
    private void Update()
    {
        _transform.localScale += scaleChangeDirection * Time.deltaTime * speed;
    }
}
