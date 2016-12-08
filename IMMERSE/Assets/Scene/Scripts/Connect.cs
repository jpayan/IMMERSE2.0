using UnityEngine;
using System.Collections;
using System.Security;
using System.Data.SqlClient;
using System.Data.Sql;
using UnityEngine.UI;

public class Connect : MonoBehaviour
{
    public Button boton;
    public InputField Username;
    public InputField Password;
    
    void Start()
    {
        boton.onClick.AddListener(() => {
            B_Connect();
        });
    }

    void B_Connect()
    {

        string url = "localhost:61670/StorageService.asmx/LogIn?UserName=" +
            Username.text + "&Password=" + Password.text
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
                Application.LoadLevel(1);
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
