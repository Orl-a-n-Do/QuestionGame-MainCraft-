using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestinController : MonoBehaviour {

	[SerializeField] private GroupButton groupButton;
	[SerializeField] private GroupAsset groupAsset;
	[SerializeField] private Text questionText;
	private QuestionAsset questionAsset;

	private List<int> usedQuestions;
	private int questionCount;

	private void OnEnable() {
		groupAsset = GameController.instance.groupAsset;
		StartQuestion();
	}

	private void Start() {
		groupButton.OnButtonClicked += CheckAnswer;
	}

	public void StartQuestion() {
		questionCount = GameController.instance.numQuestion;
		usedQuestions = new List<int>();
		GetQuestion();
	}

	public void SetPause() {
		GameController.instance.SetPause(true);
	}

	private void GetQuestion() {
		int rndNum = Random.Range(0, groupAsset.questionAssets.Length);
		for (int i = 0; i < usedQuestions.Count; i++) {
			if (usedQuestions[i] == rndNum) {
				GetQuestion();
				return;
			}
		}
		usedQuestions.Add(rndNum);
		questionAsset = groupAsset.questionAssets[rndNum];
		SetAnswers();
	}

	private void SetAnswers() {
		questionText.text = questionAsset.Question;
		groupButton.SetButtonDesc(questionAsset.answersText);
	}

	private void CheckAnswer(int id) {
		if (questionAsset.answers[id].isCorrectAnswer) {
			Score.instance.AddScore(1);
		}
		questionCount--;
		if (questionCount == 0) {
			GameController.instance.EndGame();
		} else {
			GetQuestion();
		}
	}

	private void OnDestroy() {
		groupButton.OnButtonClicked -= CheckAnswer;
	}
}
