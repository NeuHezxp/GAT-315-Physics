using UnityEngine;

public static class ScoreManager
{
    public static int score = 0;

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        Debug.Log("Current Score: " + score); // For testing purposes
        //TODO Update UI 
    }
}
