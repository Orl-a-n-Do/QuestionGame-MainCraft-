using System;
using UnityEngine;
using UnityEngine.UI;

public class GroupButton : MonoBehaviour, IInit {
	public GameObject[] buttonObjests;

	private Button[] buttons;
	private Text[] butTexts;
	private GroupButtonPressed[] groupButtonPresseds;

	public Action<int> OnButtonClicked;

	public void Init() {
		buttons = new Button[buttonObjests.Length];
		butTexts = new Text[buttonObjests.Length];
		for (int i = 0; i < buttonObjests.Length; i++) {
			buttons[i] = buttonObjests[i].GetComponent<Button>();
			butTexts[i] = buttonObjests[i].GetComponentInChildren<Text>();
		}
	}

	private void Start() {
		groupButtonPresseds = new GroupButtonPressed[buttonObjests.Length];
		for (int i = 0; i < buttonObjests.Length; i++) {
			groupButtonPresseds[i] = buttonObjests[i].AddComponent<GroupButtonPressed>();
			groupButtonPresseds[i].SetId(i);
			groupButtonPresseds[i].onButtonClick += ButtonClick;
		}
	}

	public void ButtonClick(int id) {
		OnButtonClicked?.Invoke(id);
	}

	public void SetButtonDesc(string[] desc) {
		SetVisible(false);
		if (desc.Length > buttons.Length) {
			Debug.LogError("set texts more then buttons, need fix it");
		}
		for (int i = 0; i < desc.Length; i++) {
			if (i >= buttons.Length) {
				Debug.LogError("not enoght buttons");
				break;
			}
			buttonObjests[i].SetActive(true);
			butTexts[i].text = desc[i];
		}
	}

	public void SetVisible(bool state) {
		for (int i = 0; i < buttonObjests.Length; i++) {
			buttonObjests[i].SetActive(state);
		}
	}

	private void OnDestroy() {
		for (int i = 0; i < groupButtonPresseds.Length; i++) {
			groupButtonPresseds[i].onButtonClick -= ButtonClick;
		}
	}
}
