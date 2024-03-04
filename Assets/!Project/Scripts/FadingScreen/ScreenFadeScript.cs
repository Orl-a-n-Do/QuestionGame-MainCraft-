using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScreenFadeScript : MonoBehaviour
{
    public Image overlayImage;
    public float transitionDuration = 1f;

    private Color transparentColor = new Color(0, 0, 0, 0);
    private Color blackColor = new Color(0, 0, 0, 1);

    public void FadeScreen(bool fadeOut)
    {
        if (fadeOut)
        {
            // Затемнить экран
            overlayImage.gameObject.SetActive(true);
            overlayImage.color = transparentColor;
            overlayImage.DOFade(1f, transitionDuration);
        }
        else
        {
            // Осветлить экран
            overlayImage.DOFade(0f, transitionDuration).OnComplete(() => {
                overlayImage.gameObject.SetActive(false);
            });
        }
    }
}