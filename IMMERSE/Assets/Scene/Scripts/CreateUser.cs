using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateUser : MonoBehaviour {
    public Button boton;
    public InputField Username;
    public InputField Password;
    public InputField Email;
    public InputField FirstName;
    public InputField LastName;
    public InputField Gender;


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
        string url = "localhost:61670/StorageService.asmx/SignIn?FirstName=" +
            FirstName.text + "&LastName=" + LastName.text + "&Gender=" + Gender.text + "&Email=" + Email.text + "&UserName=" + Username.text + "&Password=" + Password.text
            ;
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
                Application.LoadLevel(0);
            }
            else if (www.text.ToString().Contains("false"))
            {

            }

        }
        else
        {
            Debug.Log("Error: " + www.error.ToString());
        }
    }
}
