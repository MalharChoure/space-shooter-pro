using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class High_score_retrieval : MonoBehaviour
{
  public Text playerdisplay;
  public Text score_display;
    // Start is called before the first frame update
    void Start()
    {
        playerdisplay.text="Player"+DBmanager_script.username;
        StartCoroutine(get_score());
    }

    public void menu_scene()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator get_score()
    {
      WWWForm form = new WWWForm();
      form.AddField("username",DBmanager_script.username);
      using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:81/sqlconnect/score_display.php", form))
      {

         yield return www.SendWebRequest();
         string temp=www.downloadHandler.text;
         score_display.text="Score "+temp;
      }
    }
}
