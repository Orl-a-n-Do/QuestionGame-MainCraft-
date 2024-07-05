using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    [SerializeField] private Text resultText;

    private void OnEnable()
    {
        SetResults(Score.instance.FinalScore, Score.instance.MaxScore);
    }

    public void SetResults(int result, int maxResult)
    {
        resultText.text = $"{result} / {maxResult}";
    }

    public void ShowMenu()
    {
        GameController.instance.ReturnToMenu();
    }
}
