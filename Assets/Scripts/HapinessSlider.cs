using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HapinessSlider : MonoBehaviour
{
    [SerializeField] private TrafficLightController _myTrafficLightController;
    [SerializeField] private Slider _mySlider;
    // Start is called before the first frame update

    private void ChangeSliderValue()
    {
        _mySlider.value = _myTrafficLightController.happinessScore;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSliderValue();
    }
}
