using System;
using TMPro;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _victoryUI;

    [SerializeField]
    private TextMeshProUGUI _winnerIndex;

    public event Action OnVictory;

    private static VictoryManager _instance;

    public static VictoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("Victory Manager");
                _instance = go.AddComponent<VictoryManager>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    public void Win(int winnerIndex)
    {
        _victoryUI.SetActive(true);
        _winnerIndex.text = $"Player {winnerIndex} win !";
        OnVictory?.Invoke();
    }
    
}
