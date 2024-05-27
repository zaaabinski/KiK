using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RepeatSimulation : MonoBehaviour
{

    internal static int loopCounter=0;
    internal static int howManyLoops=0;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (loopCounter<howManyLoops)
            {
                WaitOnDemand();
            }
        }
    }

    IEnumerator WaitOnDemand()
    {
        loopCounter++;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(2);
    }
}
