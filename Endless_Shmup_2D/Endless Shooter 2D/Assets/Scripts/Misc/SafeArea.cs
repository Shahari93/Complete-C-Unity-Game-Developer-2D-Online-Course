using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    Rect safeArea;
    RectTransform transform;

    Vector2 min, max;

    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        safeArea = Screen.safeArea;

        min = safeArea.position;
        max = safeArea.size + min;

        min.x /= Screen.width;
        max.x /= Screen.width;
        min.y /= Screen.height;
        min.y /= Screen.height;

        transform.anchorMin = min;
        transform.anchorMax = max;
    }
}
