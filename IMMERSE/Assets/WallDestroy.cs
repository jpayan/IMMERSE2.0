using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WallDestroy : MonoBehaviour {
    public Text puntos;
    private int Puntaje = 0;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
      
    }
    void OnTriggerEnter(Collider _other)
    {
        print(_other.gameObject.name);
        Debug.Log(_other.gameObject.name);
        switch (_other.gameObject.name)
         {
             case "Fury(Clone)":
                 Destroy(_other.gameObject);
                 Puntaje += 1;
                 puntos.text = Puntaje.ToString();
                 break;
         }

    }
    void OnCollisionEnter(Collision _other)
    {
       
        Debug.Log(_other.gameObject.name);
        switch (_other.gameObject.name)
        {
            case "Fury(Clone)":
                Destroy(_other.gameObject);
                Puntaje += 1;
                puntos.text = Puntaje.ToString();
                break;
        }
    }
}
