using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI txtScore;

    public void SetScoreText (int score)
    {
        txtScore.text = score.ToString ();
    }
}
