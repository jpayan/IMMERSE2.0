using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ColisionadorController : MonoBehaviour
{
    public Text puntaje;
    private int Puntos;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider _other)
    {
        Puntos += 1;
        puntaje.text = Puntos.ToString();
        Destroy(_other.gameObject);

        Debug.Log("Ya" + _other.gameObject.name);
    }
}
