using UnityEngine;
using UnityEngine.UIElements;

public class SpiralController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GenerateCube[] _generateCubes;
    [SerializeField] private PositionFitter _positionFitter;
    [SerializeField] private RotateAround[] rotates;
    [SerializeField] private MoveUp _moveUp;
    [SerializeField] private ScaleChanger _scaleChanger;
    public void StartGeneration()
    {
        SetGenerateStates(true);
    }

    public void StopGeneration()
    {
        SetGenerateStates(false);
    }

    private void SetGenerateStates(bool state)
    {
        rb.isKinematic = state;
        rb.useGravity = !state;
        _positionFitter.enabled = state;
        _moveUp.enabled = state;
        _scaleChanger.enabled = state;

        foreach (var item in rotates)
        {
            item.enabled = state;
        }
        foreach (var item in _generateCubes)
        {
            item.gameObject.SetActive(state);
        }
    }

    public void SetInpulse(Vector2 forceDrection)
    {
        rb.AddForce(new Vector3(0, forceDrection.y, -forceDrection.x), ForceMode.Impulse);
    }
}
