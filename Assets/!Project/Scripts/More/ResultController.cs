using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour {
	[SerializeField] private Text resultText;

	private void OnEnable() {
		SetResults(Score.instance.FinalScore);
	}

	public void SetResults(int res) {
		resultText.text = res.ToString();
	}

	public void ShowMenu() {
		GameController.instance.ReturnToMenu();
	}
}
