using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public void ResumeGame() {
		GameController.instance.SetPause(false);
	}

	public void ShowMenu() {
		GameController.instance.ReturnToMenu();
	}
}
