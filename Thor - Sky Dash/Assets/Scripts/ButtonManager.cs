using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        Debug.Log("Game exit.");
        Application.Quit();
    }
}