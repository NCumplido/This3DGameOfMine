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
                Debug.Log("You win");
            }
            else
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
