using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class GroupButtonPressed : MonoBehaviour
{
    public const float OnClickDelay = 0.4f;
    public Action<int> onButtonClick;

    [SerializeField] private int id;
    [SerializeField] private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        if(button)
            button.onClick.RemoveListener(OnClick);
    }

    public void SetId(int id) => this.id = id;

    private void OnClick() => StartCoroutine(Invoke(OnClickDelay));

    private IEnumerator Invoke(float delay)
    {
        yield return new WaitForSeconds(delay);
        onButtonClick?.Invoke(id);

        YandexGame.FullscreenShow();
    }
}
