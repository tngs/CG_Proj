using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{

    [SerializeField] TMP_Text gameoverText;
    [SerializeField] float alphaValue;
    void Start()
    {
        SetAlpha(0);
    }
    public void gameOver()
    {
        if (!ScoreManager.Instance.isPlayerAlive)
        {
            Debug.Log("Game Over");
            SetAlpha(alphaValue);
        }
    }
    public void SetAlpha(float alpha)
    {
        // Ensure the alpha value is clamped between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        // Get the current color of the text
        Color currentColor = gameoverText.color;

        // Set the new alpha value
        currentColor.a = alpha;

        // Apply the new color back to the TMP_Text component
        gameoverText.color = currentColor;
    }
}
