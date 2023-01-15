using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] float speed;
    private void Update()
    {
        transform.Rotate(Time.deltaTime * speed, 0, 0);
    }
}
