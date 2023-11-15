using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PythonIntegration : MonoBehaviour
{
    IEnumerator PythonPost() //Asynchronous comms.
    {
        WWWForm theData = new WWWForm();
        theData.AddField("name","Sergio");
        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:5000/theChallenge", theData);

            yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        
    }
     IEnumerator PythonGet() //Asynchronous comms.
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://127.0.0.1:5000/theChallenge?name=Fede")){

        
        yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
    
    }
    }
    void Start()
    {
        StartCoroutine(PythonGet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
