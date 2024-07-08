using System.Collections;
using UnityEngine;
using YG;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject selectCategory;
    [SerializeField] private GameObject questions;
    [SerializeField] private GameObject results;
    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        GameController.instance.onChangeState += ChangeState;
        GroupButton[] groupButtons = GetComponentsInChildren<GroupButton>(true);

        for(int i = 0; i < groupButtons.Length; i++)
        {
            groupButtons[i].Init();
        }
    }
    private void OnDestroy() => GameController.instance.onChangeState -= ChangeState;

    public void ShowCategory()
    {
        startMenu.SetActive(false);
        selectCategory.SetActive(true);
    }

    private void ChangeState(GameState oldState, GameState newState)
    {
        switch(oldState)
        {
            case GameState.Menu:
                startMenu.SetActive(false);
                selectCategory.SetActive(false);
                break;

            case GameState.Game:
                if(oldState != GameState.Game || newState == GameState.Result)
                    questions.SetActive(false);
                break;

            case GameState.Pause:
                if(newState == GameState.Menu)
                    questions.SetActive(false);

                pauseMenu.SetActive(false);
                break;

            case GameState.Result:
                results.SetActive(false);
                break;
        }
        switch(newState)
        {
            case GameState.Menu:
                startMenu.SetActive(true);
                break;
            
            case GameState.Game:
                questions.SetActive(true);
                break;
            
            case GameState.Result:
                StartCoroutine(ShowFullscreen());
                results.SetActive(true);
                break;

            case GameState.Pause:
                pauseMenu.SetActive(true);
                break;
        }
    }

    private IEnumerator ShowFullscreen()
    {
        yield return new WaitForSeconds(1);
        YandexGame.FullscreenShow();
    }
}