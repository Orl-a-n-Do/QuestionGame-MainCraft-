using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestinController : MonoBehaviour
{
    public const int EndWithRemainingQuestions = 1;

    [SerializeField] private GroupButton groupButton;
    [SerializeField] private GroupAsset groupAsset;
    [SerializeField] private Text questionText;

    [Space(30f)]
    [SerializeField] private ScreenFading screenFading;
    [SerializeField] private Color _colorCorrectAnswer;
    [SerializeField] private Color _colorWrongAnswer;

    private QuestionAsset questionAsset;
    private List<int> usedQuestions;
    private int questionCount;

    private void OnEnable()
    {
        groupAsset = GameController.instance.groupAsset;
        StartQuestion();
    }

    private void Start()
    {
        groupButton.OnButtonClicked += CheckAnswer;
    }

    public void StartQuestion()
    {
        questionCount = GameController.instance.numQuestion;
        Score.instance.SetMaxScore(groupAsset.questionAssets.Length - EndWithRemainingQuestions);

        usedQuestions = new List<int>();
        GetQuestion();
    }

    public void SetPause()
    {
        GameController.instance.SetPause(true);
    }

    private void GetQuestion()
    {
        if(groupAsset.questionAssets.Length == usedQuestions.Count + EndWithRemainingQuestions)
            GameController.instance.EndGame();

        int questionNumber = Random.Range(0, groupAsset.questionAssets.Length);

        for(int i = 0; i < usedQuestions.Count; i++)
        {
            if(usedQuestions[i] == questionNumber)
            {
                GetQuestion();
                return;
            }
        }

        usedQuestions.Add(questionNumber);
        questionAsset = groupAsset.questionAssets[questionNumber];
        SetAnswers();
    }

    private void SetAnswers()
    {
        questionText.text = questionAsset.Question;
        groupButton.SetButtonDesc(questionAsset.answersText);
    }

    private void CheckAnswer(int id)
    {
        if(questionAsset.answers[id].isCorrectAnswer)
        {
            Score.instance.AddScore(1);
            screenFading.FadingColor = _colorCorrectAnswer;
        }
        else
        {
            screenFading.FadingColor = _colorWrongAnswer;
        }

        //questionCount--;
        if(questionCount == 0)
            GameController.instance.EndGame();

        else
            GetQuestion();

    }

    private void OnDestroy()
    {
        groupButton.OnButtonClicked -= CheckAnswer;
    }
}
