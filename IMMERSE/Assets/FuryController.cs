using UnityEngine;
using System.Collections;

public class FuryController : MonoBehaviour {
    private GameObject Derecha;
    
    // Use this for initialization
    void Start () {
        Derecha = GameObject.FindGameObjectWithTag("Derecha");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate((Derecha.transform.position - this.transform.position).normalized * 4 * Time.deltaTime);
    }
}
