using UnityEngine;
using System.Collections;
using System.Security;
using System.Data.SqlClient;
using System.Data.Sql;
using UnityEngine.UI;

public class Connect : MonoBehaviour {
	public Button boton;
    public InputField Username;
    public InputField Password;

    void Start()
    {
		boton.onClick.AddListener (() => {
			B_Connect ();
		});
	}
	void B_Connect()
    {
		Debug.Log ("Abro1");
        DBOperations.SignIn(Username.text,Password.text);        
    }
}
