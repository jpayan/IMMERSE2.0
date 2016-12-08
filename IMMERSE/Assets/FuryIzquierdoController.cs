using UnityEngine;
using System.Collections;

public class FuryIzquierdoController : MonoBehaviour {
    private GameObject Izquierdo;

    // Use this for initialization
    void Start()
    {
        Izquierdo = GameObject.FindGameObjectWithTag("Izquierda");
    }

    void Update()
    {
        this.transform.Translate((Izquierdo.transform.position - this.transform.position).normalized * 2 * Time.deltaTime);
    }
}
