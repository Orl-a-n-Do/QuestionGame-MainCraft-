using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SelectCategoryButton : MonoBehaviour
{
    [SerializeField] private ScreenFading _screenFading;
    [SerializeField] private MenuController _menuController;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(FadeAndShowCategory);
    }

    private void OnDestroy()
    {
        if(_button != null)
            _button.onClick.RemoveListener(FadeAndShowCategory);
    }

    private void FadeAndShowCategory()
    {
        _screenFading.OnFading—omplete += ShowCategory;
        _screenFading.Fade();
    }

    private void ShowCategory()
    {
        _screenFading.OnFading—omplete -= ShowCategory;

        _menuController.ShowCategory();
        _screenFading.Appear();
    }
}
