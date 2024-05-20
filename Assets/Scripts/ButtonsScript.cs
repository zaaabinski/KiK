using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    public void ChangeScene()
    {
        StartCoroutine(ReallySophisticatedAndComplicatedAlghorytyhmForDelayingAsMuchTimeAsPossible());
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("NAURA");
    }

    IEnumerator ReallySophisticatedAndComplicatedAlghorytyhmForDelayingAsMuchTimeAsPossible()
    {
        yield return new WaitForSeconds(0.95f);
        SceneManager.LoadScene(1);
    }
}
