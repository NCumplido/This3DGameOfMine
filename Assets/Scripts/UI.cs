using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI txtScore;

    public void SetScoreText (string score)
    {
        txtScore.text = score.ToString ();
    }
}
