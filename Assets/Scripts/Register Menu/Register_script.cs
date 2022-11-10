using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class Register_script : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Button submitButton;
    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:81/sqlconnect/register.php", form))
        {
            yield return www.SendWebRequest();
            // isNetworkError always comes true, else is to check for logs
            Debug.Log("Here");
            if (www.downloadHandler.text == "0")
            {
                Debug.Log("User created succesfully!");
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
            Debug.Log(www.downloadHandler.text);
        }
    }
    public void VerifyInput()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
