using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class login_script : MonoBehaviour
{
  public InputField nameField;
  public InputField passwordField;
  public Button submitButton;
  public void CallLogin()
  {
      StartCoroutine(Loginplayer());
  }
  IEnumerator Loginplayer()
  {
    WWWForm form = new WWWForm();
    form.AddField("username", nameField.text);
    form.AddField("password", passwordField.text);
    using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:81/sqlconnect/login.php", form))
    {

      yield return www.SendWebRequest();
      Debug.Log(www.downloadHandler.text);
      if (www.downloadHandler.text != "-1" && www.downloadHandler.text != "")
      {
          DBmanager_script.username= nameField.text;
          DBmanager_script.score=www.downloadHandler.text;
          Debug.Log(DBmanager_script.username);
          UnityEngine.SceneManagement.SceneManager.LoadScene(0);
      }
      else
      {
         Debug.Log("Error");
         Debug.Log(www.downloadHandler.text);
      }
    }
  }
  public void VerifyInput()
  {
      submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
  }
}
