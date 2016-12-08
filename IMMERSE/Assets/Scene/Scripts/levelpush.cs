using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class levelpush : MonoBehaviour {
    public Button boton;
	// Use this for initialization
	void Start () {
        boton.onClick.AddListener(() => {
            B_Connect();
        });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void B_Connect()
    {

        Application.LoadLevel(2);
    }
}
