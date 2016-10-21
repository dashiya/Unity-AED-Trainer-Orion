using UnityEngine;
using System.Collections;

public class PadButtonBlink : MonoBehaviour
{

    public Renderer padrend;
    public GameObject Padlocate1, Padlocate2;

    void Start()
    {
        Padlocate1 = GameObject.Find("パッド位置ランプ　右");
        Padlocate2 = GameObject.Find("パッド位置ランプ　左");
        padrend = GetComponent<Renderer>();
        padrend.enabled = true;
    }

    // Toggle the Object's visibility each second.
    void Update()

    {   //if(二枚のパッドが両方とも貼り付けられていなければ)
        if (FlagManager.Instance.flags[0] == true && FlagManager.Instance.flags[4] == false)
        {

            // Find out whether current second is odd or even
            bool oddeven = Mathf.FloorToInt(Time.time) % 2 == 0;

            // Enable renderer accordingly
            padrend.enabled = oddeven;
        }
    }
}

