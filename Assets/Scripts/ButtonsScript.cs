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
        StartCoroutine(MomentBeforeYouRunAwayToYourMother());
    }

    IEnumerator ReallySophisticatedAndComplicatedAlghorytyhmForDelayingAsMuchTimeAsPossible()
    {
        yield return new WaitForSeconds(3.2f);
        SceneManager.LoadScene(1);
    }

    IEnumerator MomentBeforeYouRunAwayToYourMother()
    {
        yield return new WaitForSeconds(0.95f);
        Application.Quit();
        Debug.Log("NAURA");
    }
}
