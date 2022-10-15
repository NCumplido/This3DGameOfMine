using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI txtScore;

    public HealthBar healthBar;
    public void SetScoreText (string score)
    {
        txtScore.text = score.ToString ();
    }
}
