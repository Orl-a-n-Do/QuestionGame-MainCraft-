using System;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionAsset", menuName = "Project/QuestionAsset", order = 0)]
public class QuestionAsset : ScriptableObject {
	public string Question;
	public AnswerStruct[] answers;
	public string[] answersText;

	private void OnValidate() {
		answersText = new string[answers.Length];
		for(int i = 0; i < answers.Length; i++) {
			answersText[i] = answers[i].Answer;
		}
	}
}

[Serializable]
public struct AnswerStruct {
	public string Answer;
	public bool isCorrectAnswer;
}
