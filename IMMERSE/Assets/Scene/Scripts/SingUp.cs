using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SingUp : MonoBehaviour {

	public Button boton;
    public InputField Username;

    void Start(){
		boton.onClick.AddListener (() => {
			B_Connect ();
		});

	}
	void B_Connect()
    {

        string url = "localhost:61670/StorageService.asmx/Check?UserName=" + Username.text;
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        if (www.error == null)
        {
            if (www.text.ToString().Contains("true"))
            {
                Debug.Log("Error: UserName already exists.");
            }
            else if (www.text.ToString().Contains("false"))
            {
                Application.LoadLevel(3);
            }

        }
        else
        {
            Debug.Log("Error: " + www.error.ToString());


        }
    }

}
