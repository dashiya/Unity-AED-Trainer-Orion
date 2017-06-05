using UnityEngine;
using System.Collections;

public class DestroyWear : MonoBehaviour
{

    LeapHandCollision hc = new LeapHandCollision();

  public  bool isWearDestoroy = false;

    GameObject wearChild;
    GameObject openButton;



    // Use this for initialization
    void Start()
    {

        openButton = GameObject.Find("開閉ボタン");
      wearChild =  GameObject.Find("Wear Object");

    }

    void OnTriggerEnter(Collider obj)
    {
        OpenButton ob = openButton.GetComponent<OpenButton>();
        if (ob.isWearSound == true && hc.IsHand(obj))
        {
            isWearDestoroy = true;
            Destroy(wearChild);
     
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isWearDestoroy);
     
    }
}
