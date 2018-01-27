using UnityEngine;

public class Floating : MonoBehaviour
{
    public float MinSpeed;
    public float MaxSpeed;
    public float MinRotation;
    public float MaxRotation;

    private float _randomHorizontalSpeed;
    private float _randomVerticalSpeed;
    private float _randomRotationSpeed;

    void Start()
    {
        _randomHorizontalSpeed = Random.Range(MinSpeed, MaxSpeed);
        _randomVerticalSpeed = Random.Range(MinSpeed, MaxSpeed);
        _randomRotationSpeed = Random.Range(MinRotation, MaxRotation);
    }

    void Update()
    {
        var oldPosition = transform.position;
        var newXPosition = oldPosition.x + _randomHorizontalSpeed;
        var newYPosition = oldPosition.y + _randomVerticalSpeed;

        transform.position = new Vector3(newXPosition, newYPosition, oldPosition.z);
        transform.Rotate(Vector3.forward, _randomRotationSpeed);
    }
}
