using UnityEngine;
using System.Collections;

public class FuryCenterController : MonoBehaviour {
    private GameObject Center;

    // Use this for initialization
    void Start()
    {
        Center = GameObject.FindGameObjectWithTag("Centro");
    }

    void Update()
    {
        this.transform.Translate((Center.transform.position - this.transform.position).normalized * 4 * Time.deltaTime);
    }
}
