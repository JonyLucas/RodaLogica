using UnityEngine;

namespace Game.Props
{
    public class ObjectiveAnimation : MonoBehaviour
    {
        [SerializeField]
        private float maxScale, minScale; // The maximum and minimum size of the object.

        private float currentScale;

        [SerializeField]
        private float animationRate; // The animation speed, determines how fast the logo increase and decrease.

        private bool increase = true; // Boolean to determine if the logo is increasing or decreasing size.

        // Use this for initialization
        private void Start()
        {
            currentScale = transform.localScale.x;
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
            transform.localScale = new Vector3(currentScale, currentScale, 1);
        }
    }
}