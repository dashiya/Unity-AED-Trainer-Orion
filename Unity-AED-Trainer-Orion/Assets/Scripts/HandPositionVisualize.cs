using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//Todo:スライダーの最小、最大値を手の位置に適したものに→ChestComplessionのBoxColliderに触れた時のhp.ConvertPosition.yを取得してスライダーの値に反映させるといいかも　
public class HandPositionVisualize : MonoBehaviour {

    Slider _slider;

	// Use this for initialization
	void Start () {
        _slider = this.GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        HandPosition hp = GetComponent<HandPosition>();

        _slider.value = hp.ConvertPosition.y;
        Debug.Log(hp.ConvertPosition.y + "HandPos" + _slider.value + "slider");

    }
}
