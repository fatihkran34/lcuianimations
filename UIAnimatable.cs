using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LCUI;

public class UIAnimatable : MonoBehaviour
{
    [SerializeField] private bool Move;
    [SerializeField] private UIMoveAnimation moveAnimation;


    [SerializeField] private bool Scale;
    [SerializeField] private UIScaleAnimation scaleAnimation;

    [SerializeField] private bool Fade;
    [SerializeField] private UIFadeAnimation fadeAnimation;

    [SerializeField] private bool deactivateOnHide=true;
    [SerializeField] private bool hideAtStart=true;


    private RectTransform rectTransform;
    private int animationCount;
    private bool isActive=false;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        if (hideAtStart)
        {
            gameObject.SetActive(false);
        }
        if (gameObject.activeSelf)
        {
            isActive = true;
        }
    }

    public void Show()
    {
        if (isActive)
        {
            return;
        }
        gameObject.SetActive(true);
        isActive = true;
        if (Move)
        {
            moveAnimation.Show(rectTransform);
        }

        if (Scale)
        {
            scaleAnimation.Show(rectTransform);
        }
        if (Fade)
        {
            if (GetComponent<CanvasGroup>()!=null)
            {
                fadeAnimation.Show(rectTransform);
            }
            else
            {
                Debug.LogWarning("There is no canvas group");
            }
        }
    }

    public void Hide(bool instant=false)
    {
        if (isActive==false)
        {
            return;
        }
        isActive = false;
        if (instant)
        {
            gameObject.SetActive(false);
            return;
        }
        if (Move)
        {
            moveAnimation.OnEndEvent = OnAnimationHide;
            moveAnimation.Hide(rectTransform);
            animationCount++;
        }
        if (Scale)
        {
            scaleAnimation.OnEndEvent = OnAnimationHide;
            scaleAnimation.Hide(rectTransform);
            animationCount++;
        }

        if (Fade)
        {
            if (GetComponent<CanvasGroup>() != null)
            {
                fadeAnimation.OnEndEvent = OnAnimationHide;
                fadeAnimation.Hide(rectTransform);
                animationCount++;
            }
            else
            {
                Debug.LogWarning("There is no canvas group");
            }
        }
    }

    private void OnAnimationHide()
    {
        animationCount--;
        if (animationCount==0)
        {
            if (deactivateOnHide)
            {
                gameObject.SetActive(false);
            }
        }
    }

}
