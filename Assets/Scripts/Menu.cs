using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);//FUTURE: use ScenesEnum
    }
    
    public void OnQuitButton()
    {
        Application.Quit();
    }
}