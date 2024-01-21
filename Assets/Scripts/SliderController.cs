using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Text valueText;
    int progress = 0;
    public Slider slider;
    // public LineSettings lineSettings; // Add this line

    // public void Start() {
    //     slider.value = lineSettings.distanceFromCamera;
    // }
    
    public void OnSliderChanged(float value) {
        // lineSettings.distanceFromCamera = value; // Update the distanceFromCamera value
        valueText.text = value.ToString();
    }
 
    public void UpdateProgress() {
        progress++;
        slider.value = progress;
    }

    public void RemoveProgress() {
        progress--;
        slider.value = progress;
    }
}