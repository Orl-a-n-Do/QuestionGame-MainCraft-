using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GroupButtonPressed : MonoBehaviour
{
    public const float OnClickDelay = 0.15f;
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
    }
}
