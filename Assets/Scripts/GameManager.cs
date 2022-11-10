using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver=false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && _isGameOver==true)
        {
            StartCoroutine(update_score());
            SceneManager.LoadScene(1);
        }
        if(Input.GetKeyDown(KeyCode.B) && _isGameOver==true)
        {
            StartCoroutine(update_score());
            SceneManager.LoadScene(0);
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    IEnumerator update_score()
    {
      WWWForm form = new WWWForm();
      form.AddField("username",DBmanager_script.username);
      int temp=GameObject.Find("Canvas").GetComponent<UIManager>().look_up_able_score;
      form.AddField("score",temp);
      using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:81/sqlconnect/addscore.php", form))
      {

         yield return www.SendWebRequest();
         if (www.downloadHandler.text == "0")
         {
             Debug.Log("Score_updated");
         }
         else
         {
            Debug.Log("error");
            Debug.Log(www.downloadHandler.text);
         }
      }
    }
}
