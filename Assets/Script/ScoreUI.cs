using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    private void Update()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.GetScore();
    }
}
