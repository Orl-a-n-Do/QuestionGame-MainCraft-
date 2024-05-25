using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class GroupButtonPressed : MonoBehaviour
{
    public const float OnClickDelay = 1f;
    public Action<int> OnButtonClick;

    [SerializeField] private int _id;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        if(_button)
            _button.onClick.RemoveListener(OnClick);
    }

    public void SetId(int id) => _id = id;

    private void OnClick() => StartCoroutine(Invoke(OnClickDelay));

    private IEnumerator Invoke(float delay)
    {
        Singleton<ScreenFading>.Instance.Fade(delay);
        yield return new WaitForSeconds(delay);

        Singleton<ScreenFading>.Instance.Appear(delay);
        OnButtonClick?.Invoke(_id);
    }
}
