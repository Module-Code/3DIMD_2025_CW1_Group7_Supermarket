using UnityEngine;
using UnityEngine.UI;

public class RotationSlider : MonoBehaviour
{
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, slider.value, 0);
    }
}
