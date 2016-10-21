using UnityEngine;
using System.Collections;

public class AudiotimeManager : MonoBehaviour {

    public static ulong audioDelay = 128 * 100;

    private static AudiotimeManager instance = null;
    public static AudiotimeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudiotimeManager>();

                if (instance == null)
                {
                    instance = new GameObject("AudiotimeManager").AddComponent<AudiotimeManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (Instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
