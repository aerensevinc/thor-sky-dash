using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject panel;
    public string sceneName;

    public void GoToScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Debug.Log("Exit game.");
        Application.Quit();
    }

    public void ActivatePanel()
    {
        panel.SetActive(true);
    }

    public void DeactivatePanel()
    {
        panel.SetActive(false);
    }
}