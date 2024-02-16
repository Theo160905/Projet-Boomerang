using UnityEngine;
using TMPro;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField]
    private PlayerScore _playerScore;

    [SerializeField]
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text.text = "0";
        _playerScore.OnScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int newScore)
    {
        _text.text = newScore.ToString();
    }
}
