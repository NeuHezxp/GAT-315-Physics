using UnityEngine;
using TMPro; // Include the TextMeshPro namespace

public class ScoreManager : MonoBehaviour
{
    public static int Score = 0; // Static score so it can be easily accessed from other scripts without needing a reference to the ScoreManager
    public TextMeshProUGUI scoreText; 

    void Update()
    {
        scoreText.text = "Score: " + Score; // Update the score display every frame
    }
}
