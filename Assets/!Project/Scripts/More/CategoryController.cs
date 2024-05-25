using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryController : MonoBehaviour {
	[SerializeField] private GroupButton groupButton;
	[SerializeField] private CategoryAsset categories;

	private void Start() {
		groupButton.SetButtonDesc(categories.categoriesText);
		groupButton.OnButtonClicked += SetCategory;
	}

	private void SetCategory(int id) {
		GameController.instance.SelectCategory(categories.groupAssets[id]);
	}

	private void OnDestroy() {
		groupButton.OnButtonClicked -= SetCategory;
	}
}
