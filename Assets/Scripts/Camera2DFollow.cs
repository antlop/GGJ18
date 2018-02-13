using UnityEngine;

public class Camera2DFollow : MonoBehaviour
{
    public string TagNameToFollow = "Player";
    public float Damping = 0.5f;
    public Transform StartOfLevel;
    public Transform TopOfLevel;
    public Transform BottomOfLevel;

    private Transform[] _targets;
    private int _targetLength;
    private Vector3 _currentVelocity;
    private float _startOfLevelX;
    private float _topOfLevelY;
    private float _bottomOfLevelY;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        _startOfLevelX = StartOfLevel.position.x;
        _topOfLevelY = TopOfLevel.position.y;
        _bottomOfLevelY = BottomOfLevel.position.y;
    }

    void Update()
    {
        LookForTargets();
        if (_targets.Length == 0)
        {
            return;
        }

        float minX = _targets[0].position.x;
        float maxX = minX;

        float minY = _targets[0].position.y;
        float maxY = minY;

        for (int i = 1; i < _targetLength; i++)
        {
            var currentX = _targets[i].position.x;

            if (currentX > maxX)
                maxX = currentX;

            if (currentX < minX)
                minX = currentX;
        }

        for (int i = 1; i < _targetLength; i++)
        {
            var currentY = _targets[i].position.y;

            if (currentY > maxY)
                maxY = currentY;

            if (currentY < minY)
                minY = currentY;
        }

        var currentPosition = transform.position;
        var distanceBetweenPlayers = maxX - minX;
        var newX = Mathf.Clamp(minX + (distanceBetweenPlayers / 2f), _startOfLevelX, float.MaxValue);
        var newY = Mathf.Clamp(minY + (distanceBetweenPlayers / 2f), _bottomOfLevelY, _topOfLevelY);

        var targetPosition = new Vector3(newX, newY, currentPosition.z);
        var newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, Damping);

        transform.position = newPosition;
    }

    public void LookForTargets()
    {
        var targetObjects = GameObject.FindGameObjectsWithTag(TagNameToFollow);

        _targetLength = targetObjects.Length;
        _targets = new Transform[_targetLength];
        for (int i = 0; i < _targetLength; i++)
        {
            _targets[i] = targetObjects[i].transform;
        }
    }
}
