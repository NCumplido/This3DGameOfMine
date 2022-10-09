using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI txtScore;
    public Image imgHalthFill;

    public void SetScoreText (string score)
    {
        txtScore.text = score.ToString ();
    }

    public void SetHealth(int health)
    {
        imgHalthFill.fillAmount = health;
    }
}
