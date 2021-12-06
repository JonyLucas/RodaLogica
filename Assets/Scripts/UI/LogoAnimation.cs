using UnityEngine;

/// <summary>
/// This class is used for the Logo animation on the Title Screen. It makes the Logo grow up and decrease.
/// </summary>
public class LogoAnimation : MonoBehaviour
{
    [SerializeField]
    private float maxScale, minScale; // The maximum and minimum size of the Logo.

    private float currentScale;

    [SerializeField]
    private float animationRate; // The animation speed, determines how fast the logo increase and decrease.

    private bool increase = true; // Boolean to determine if the logo is increasing or decreasing size.

    private RectTransform rectTransform;

    // Use this for initialization
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        currentScale = rectTransform.localScale.x;
    }

    // Update is called once per frame
    private void Update()
    {
        if (increase)
        {
            currentScale += animationRate;
            if (currentScale > maxScale)
                increase = false;
        }
        else
        {
            currentScale -= animationRate;
            if (currentScale < minScale)
                increase = true;
        }
        rectTransform.localScale = new Vector3(currentScale, currentScale, 1);
    }
}