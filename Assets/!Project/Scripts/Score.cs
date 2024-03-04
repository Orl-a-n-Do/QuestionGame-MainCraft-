using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
	public static Score instance;
	public int FinalScore => score;
	private int score;

	private void Awake() {
		instance = this;
	}

	public void AddScore(int n) {
		score += n;
	}

	public void ResetScore() {
		score = 0;
	}
}
