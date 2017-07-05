using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HandPositionVisualize : MonoBehaviour
{
    Slider _slider;

    // Use this for initialization
    void Start()
    {
        _slider = this.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        HandPosition hp = GetComponent<HandPosition>();

        _slider.value = hp.ConvertPosition.y;
    }
}
