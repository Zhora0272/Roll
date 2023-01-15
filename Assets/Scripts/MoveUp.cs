using UnityEngine;

public class MoveUp : MonoBehaviour
{
    [SerializeField] float speed;

    private float firstSpeed;
    private void Start()
    {
        firstSpeed = speed;
    }
    private void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * speed);
        speed += Time.deltaTime * firstSpeed;
    }
}
