using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SingUp : MonoBehaviour {

	public Button boton;

	void Start(){
		boton.onClick.AddListener (() => {
			B_Connect ();
		});

	}
	void B_Connect(){

		Debug.Log ("Abro");
	}
}
