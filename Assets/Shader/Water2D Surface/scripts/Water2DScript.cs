// 2016 - Damien Mayance (@Valryon)
// Source: https://github.com/valryon/water2d-unity/
using UnityEngine;

/// <summary>
/// Water surface script (update the shader properties).
/// </summary>
public class Water2DScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(0.01f, 0f);

    private Renderer rend;
    private Material mat;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;
    }

    void LateUpdate()
    {
        // Determine how many world points are in the current resolution
        // This is done every frame because the resolution could change at any time
        var minWorldPointsInResolution = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
        var maxWorldPointsInResolution = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        var screenWidthToWorldPoint = maxWorldPointsInResolution.x - minWorldPointsInResolution.x;
        var screenHeightToWorldPoint = maxWorldPointsInResolution.y - minWorldPointsInResolution.y;

        // Once you know how many world points the screen is, that's what the size of the water effect should be.
        transform.localScale = new Vector3(screenWidthToWorldPoint, screenHeightToWorldPoint);

        Vector2 scroll = Time.deltaTime * speed;

        mat.mainTextureOffset += scroll;
    }
}