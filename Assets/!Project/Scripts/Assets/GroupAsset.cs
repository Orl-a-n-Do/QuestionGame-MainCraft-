using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GroupAsset", menuName = "Project/GroupAsset", order = 0)]
public class GroupAsset : ScriptableObject {
	public string GroupName;
	public QuestionAsset[] questionAssets;
}
