using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);//FUTURE: use ScenesEnum
    }
    
    public void OnLoadButton()
    {
        var levelToLoad =  SaveSystem.LoadPlayer();
        if(levelToLoad > 0)
        {
            SceneManager.LoadScene(levelToLoad);
        }
        else if( levelToLoad == 0)
        {
            //FUTURE: Show text
        }
    }
    
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
