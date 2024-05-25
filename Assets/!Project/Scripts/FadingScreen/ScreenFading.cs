using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ScreenFading : MonoBehaviour
{
    public event Action OnFading�omplete;
    
    [SerializeField] private float _defaultTransitionDuration = 1f;
    [SerializeField] private Color _transparentColor = new(0, 0, 0, 0);
    [SerializeField] private Color _blackColor = new(0, 0, 0, 1);
    
    private Image _overlayImage;

    private void Awake() => _overlayImage = GetComponent<Image>();

    public void Appear(float duration = -1)
    {
        Debug.Log("���������� ������");

        if(duration <= 0)
            duration = _defaultTransitionDuration;

        _overlayImage
            .DOFade(_transparentColor.a, duration)
            .OnComplete(() => OnFading�omplete?.Invoke())
            .OnComplete(() => _overlayImage.raycastTarget = false);
    }

    public void Fade(float duration = -1)
    {
        Debug.Log("���������� ������");

        if(duration <= 0)
            duration = _defaultTransitionDuration;

        _overlayImage.color = _transparentColor;
        _overlayImage.raycastTarget = true;

        _overlayImage
            .DOFade(_blackColor.a, duration)
            .OnComplete(() => OnFading�omplete?.Invoke());
    }
}