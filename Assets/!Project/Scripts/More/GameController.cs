using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private GameState curGameState;
    public GroupAsset groupAsset; 
    public Action<GameState, GameState> onChangeState;
    public static GameController instance;
    public int numQuestion;
    public bool isPause;

	private void Awake() {
        instance = this;
	}

	private void SetState(GameState state) {
        onChangeState?.Invoke(curGameState, state);
        curGameState = state;
    }

    public void SelectCategory(GroupAsset group) {
        groupAsset = group;
        Score.instance.ResetScore();
        SetState(GameState.Game);
	}

    public void SetPause(bool state) {
        isPause = state;
		if (isPause) {
            SetState(GameState.Pause);
		} else {
            SetState(GameState.Game);
		}
	}

    public void EndGame() {
        SetState(GameState.Result);
	}

    public void ReturnToMenu() {
        SetState(GameState.Menu);
	}
}
public enum GameState {
    Menu,
    Game,
    Pause,
    Result
}
