using UnityEngine;
using System.Collections;

public class Personaje : MonoBehaviour {

    public GameObject Avatar;
    public static Personaje Instance;
    public static Personaje instance()
    {
        if (Instance==null)
        {
            Instance = new Personaje();
        }
        return Instance;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
