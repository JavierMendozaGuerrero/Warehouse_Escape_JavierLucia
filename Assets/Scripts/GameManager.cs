using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum EndState { None, Win, Lose }

    public bool hasObjective { get; private set; }
    public bool isGameOver { get; private set; }
    public EndState endState { get; private set; } = EndState.None;

    public event Action<EndState> GameEnded;

    private void Awake()
    {
        
        hasObjective = false;
        isGameOver = false;
        endState = EndState.None;

        GuardRobot.ResetAlarmEvent();
    }

    public void OnObjectiveCollected()
    {
        if (isGameOver) return;
        hasObjective = true;
        Debug.Log("Objetivo recogido");
    }

    public void OnThiefEscaped()
    {
        if (isGameOver) return;
        isGameOver = true;
        endState = EndState.Win;
        Debug.Log("GANASTE (thief escaped)");
        GameEnded?.Invoke(endState);
    }

    public void OnThiefCaught()
    {
        if (isGameOver) return;
        isGameOver = true;
        endState = EndState.Lose;
        Debug.Log("PERDISTE (thief caught)");
        GameEnded?.Invoke(endState);
    }
}
