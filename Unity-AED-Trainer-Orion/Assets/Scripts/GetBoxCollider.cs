using UnityEngine;
using System.Collections;

public class GetBoxCollider : MonoBehaviour
{
    LeapHandCollision _hc = new LeapHandCollision();
    // Use this for initialization
    void Start()
    {
         Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.white);
    }

    void OnTriggerStay(Collider other)
    {

        if (_hc.IsHand(other))
        {
            Debug.Log("手が触れたよ");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}