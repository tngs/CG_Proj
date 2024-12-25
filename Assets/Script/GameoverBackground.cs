using UnityEngine;
using UnityEngine.UI;

public class GameoverBackground : MonoBehaviour
{
    [SerializeField] RawImage gameoverImage; // Keep using RawImage
    [SerializeField] float alphaValue;

    void Start()
    {
        SetAlpha(0); // Start with alpha set to 0
    }

    public void gameOver()
    {
        if (!ScoreManager.Instance.isPlayerAlive)
        {
            Debug.Log("Game Over by background"); // Log message for game over
            SetAlpha(alphaValue); // Set alpha to the specified value
        }
    }

    public void SetAlpha(float alpha)
    {
        // Ensure the alpha value is clamped between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        // Get the current color of the RawImage
        Color currentColor = gameoverImage.color;

        // Set the new alpha value
        currentColor.a = alpha;

        // Apply the new color back to the RawImage component
        gameoverImage.color = currentColor; // Update the RawImage color
    }
}