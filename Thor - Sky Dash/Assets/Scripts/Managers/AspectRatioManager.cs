using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class AspectRatioManager : MonoBehaviour
{
    public Vector2 targetAspect = new Vector2(9f, 16f);

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Camera camera = GetComponent<Camera>();

        float target = targetAspect.x / targetAspect.y;
        float window = (float)Screen.width / Screen.height;

        if (Mathf.Approximately(window, target))
        {
            camera.rect = new Rect(0f, 0f, 1f, 1f);
        }
        else if (window > target)
        {
            float scale = target / window;
            float xOffset = (1f - scale) / 2f;
            camera.rect = new Rect(xOffset, 0f, scale, 1f);
        }
        else
        {
            float scale = window / target;
            float yOffset = (1f - scale) / 2f;
            camera.rect = new Rect(0f, yOffset, 1f, scale);
        }
    }
}