using UnityEngine;
using System.Collections;

public class DestroyWear : MonoBehaviour
{

    LeapHandCollision hc = new LeapHandCollision();

    bool isTouchWear = false;
    

    GameObject openButton;



    // Use this for initialization
    void Start()
    {

        openButton = GameObject.Find("開閉ボタン");


    }

    void OnTriggerEnter(Collider obj)
    {
        OpenButton ob = openButton.GetComponent<OpenButton>();
        if (ob.isWearSound == true && hc.IsHand(obj))
        {
            isTouchWear = true;

           
        }
    }

    // Update is called once per frame
    void Update()
    {
        OpenButton ob = openButton.GetComponent<OpenButton>();
        if (ob.isWearSound == true && isTouchWear == true)
        {
            Destroy(gameObject);

            ob.isWearDestoroy = true;
        }


    }
}
