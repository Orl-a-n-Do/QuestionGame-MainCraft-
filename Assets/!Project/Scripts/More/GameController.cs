using System;
using UnityEngine;

public enum GameState
{
    Menu,
    Game,
    Pause,
    Result
}

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GroupAsset groupAsset;
    public Action<GameState, GameState> onChangeState;

    public int numQuestion;
    public bool isPause;

    [SerializeField] private GameState curGameState;

    private void Awake()
    {
        instance = this;
    }

    private void SetState(GameState state)
    {
        onChangeState?.Invoke(curGameState, state);
        curGameState = state;
    }

    public void SelectCategory(GroupAsset group)
    {
        groupAsset = group;
        Score.instance.ResetScore();
        SetState(GameState.Game);
    }

    public void SetPause(bool state)
    {
        isPause = state;

        if(isPause)
            SetState(GameState.Pause);
        
        else
            SetState(GameState.Game);
    }

    public void EndGame() => SetState(GameState.Result);

    public void ReturnToMenu() => SetState(GameState.Menu);
}
