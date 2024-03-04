using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GategoryAsset", menuName = "Project/GategoryAsset", order = 0)]
public class CategoryAsset : ScriptableObject {
	public GroupAsset[] groupAssets;

	public string[] categoriesText;

	private void OnValidate() {
		categoriesText = new string[groupAssets.Length];

		for(int i = 0; i < groupAssets.Length; i++) {
			categoriesText[i] = groupAssets[i].GroupName;
		}
	}
}
