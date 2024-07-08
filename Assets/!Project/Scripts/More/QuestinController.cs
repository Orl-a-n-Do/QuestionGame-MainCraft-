using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestinController : MonoBehaviour
{
    public const int EndWithRemainingQuestions = 1;

    [SerializeField] private GroupButton groupButton;
    [SerializeField] private GroupAsset groupAsset;
    [SerializeField] private Text questionText;
    [SerializeField] private TMP_Text completedQuestions;

    [Space]
    [SerializeField] private ScreenFading screenFading;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip rigthAudioClip;
    [SerializeField] private AudioClip dontRigthAudioClip;

    private QuestionAsset questionAsset;
    private List<int> usedQuestions;
    private int questionCount;

    private void OnEnable()
    {
        groupAsset = GameController.instance.groupAsset;
        StartQuestion();
    }

    private void Start() => groupButton.OnButtonClicked += CheckAnswer;

    private void OnDestroy() => groupButton.OnButtonClicked -= CheckAnswer;

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
        completedQuestions.text = $"{usedQuestions.Count} / {groupAsset.questionAssets.Length - EndWithRemainingQuestions}";
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
            audioSource.clip = rigthAudioClip;
        }
        else
        {
            audioSource.clip = dontRigthAudioClip;
        }

        audioSource.Play();

        //questionCount--;
        if(questionCount == 0)
            GameController.instance.EndGame();

        else
            GetQuestion();
    }
}
