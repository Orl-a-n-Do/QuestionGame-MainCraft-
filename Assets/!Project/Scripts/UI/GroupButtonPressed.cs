using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupButtonPressed : MonoBehaviour
{
    [SerializeField] private int id;
	[SerializeField] private Button button;

    public Action<int> onButtonClick;

	private void Start() {
		button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
	}

	private void OnClick() {
		onButtonClick?.Invoke(id);
	}

	public void SetId(int id) {
		this.id = id;
	}

	private void OnDestroy() {
		if (button)
			button.onClick.RemoveListener(OnClick);
	}
}
