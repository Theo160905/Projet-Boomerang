using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score {  get; private set; }

    public event Action<int> OnScoreChanged;

    public void AddPoint()
    {
        Score++;
        if (Score == 5)
        {
            Win();
        }
        OnScoreChanged?.Invoke(Score);
    }

    private void Win()
    {
        int playerId = GetComponentInParent<PlayerControllerAmbre>().id;

        VictoryManager.Instance.Win(playerId);
    }
}
