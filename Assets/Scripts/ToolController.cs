using UnityEngine;

public class ToolController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private SpiralController _spiralPrefab;
    [SerializeField] private Transform _point;
    [SerializeField] private float _toolDownDegree;
    [SerializeField] private float _toolUpDegree;
    [SerializeField] private float _toolDownYPos;
    [SerializeField] private float _toolUpYPos;

    private SpiralController currnetSpiralController;

    private float _toolTargetDegree;
    private float _toolTargetYPos;

    private void Start()
    {
        _toolTargetDegree = _toolUpDegree;
        _toolTargetYPos = _toolUpYPos;
        _particleSystem.Stop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _toolTargetDegree = _toolDownDegree;
            _toolTargetYPos = _toolDownYPos;
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            _toolTargetDegree = _toolUpDegree;
            _toolTargetYPos = _toolUpYPos;

            if (currnetSpiralController)
            {
                currnetSpiralController.transform.parent = null;
                currnetSpiralController.StopGeneration();
                currnetSpiralController.SetInpulse(new Vector2(150,20));
                _particleSystem.Stop();
            }
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, _toolTargetDegree), Time.deltaTime * 5);
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, _toolTargetYPos, 0), Time.deltaTime * 5);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            _particleSystem.Play();
            currnetSpiralController = Instantiate(_spiralPrefab, _point);
            currnetSpiralController.gameObject.SetActive(true);
        }
    }
}
