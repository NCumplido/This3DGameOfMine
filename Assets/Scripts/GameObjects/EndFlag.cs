using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    public string nextSceneName;
    public bool lastLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lastLevel)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SaveSystem.SetPlayerState(other.GetComponent<Player>());
                SaveSystem.SavePlayer(other.GetComponent<Player>());
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
