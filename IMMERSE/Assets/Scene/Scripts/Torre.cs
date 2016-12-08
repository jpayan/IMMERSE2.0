using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Torre : MonoBehaviour {

    public Transform canon;
    public Transform Misil_SpawPoint;
    public GameObject Misil;

    public Text Countdown;
    public float tiempo=5f;

    const float RotationSpeed = 50f;
    const float UmbralAngulo = 0.0349065f;
    public float Reload;
    float DelayDisparo;

    public GameObject Personaje;

    private GameObject B, C;

    void Start()
    {
        Countdown.text = tiempo.ToString();

        if (this.gameObject.name == "Tower2")
        {
            Reload = 4f;
        }
        else if(this.gameObject.name=="Tower")
        {
            Reload = 6f;
        }
        else if(this.gameObject.name=="Tower3")
        {
            Reload = 10f;
        }
    }
    
    void Update()
    {
        tiempo -=  Time.deltaTime;
       
        Countdown.text = tiempo.ToString();
        if (tiempo<=0)
        {

            Countdown.enabled = false;
            if (DelayDisparo > Time.time) return;
            {
                //Calculamos La Distancia
                Vector3 DirrecionObjetivo = Personaje.transform.position - canon.position;
                DirrecionObjetivo.Normalize();
                //Calcular el Angulo entre la torre y el tanque
                float EnQueSentido = Vector3.Cross(canon.forward, DirrecionObjetivo).y;//Return ANGULO EN RADIANES
                                                                                       //Giramos La Torreta
                canon.Rotate(0f, Mathf.Sign(EnQueSentido) * RotationSpeed * Time.deltaTime, 0f, Space.World);

                if (Mathf.Abs(EnQueSentido) < UmbralAngulo)
                {
                    //La Torreta Ya Tiene en la Mira al Tanque
                    //T.PlayOneShot(Explo);
                    Instantiate(Misil, Misil_SpawPoint.position, Misil_SpawPoint.rotation);
                    DelayDisparo = Time.time + Reload;
                }

            }
        }
        
      



    }

}
