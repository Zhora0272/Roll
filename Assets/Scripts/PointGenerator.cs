using System.Collections;
using UnityEngine;

public class PointGenerator : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    private void Start()
    {
        StartCoroutine(MakePoint());
    }

    IEnumerator MakePoint()
    {
        float distance = 0.01f;
        float degree = 360;
        while(true)
        {
            yield return null;
            _transform.transform.eulerAngles = new Vector3(degree, 0, 0);
            degree += 7.5f;

            var obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj.transform.position = _transform.position + _transform.forward * distance;
       
            distance += 0.001f;
            
            obj.transform.localScale = Vector3.one / 50;
            
        }
    }
}
