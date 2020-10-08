using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace LCUI
{
    public abstract class UIAnimation
    {
        public Ease Ease;
        public float Delay;
        public float Time;

        public System.Action OnEndEvent;



        public abstract void Show(RectTransform transform);

        public abstract void Hide(RectTransform transform);


        protected void OnHide()
        {
            OnEndEvent.Invoke();
        }
    }

    [System.Serializable]
    public class UIMoveAnimation : UIAnimation
    {
        public ScreenPosition From;

        public override void Hide(RectTransform transform)
        {
            transform.DOAnchorPos(GetScreenPosition(), Time).SetDelay(Delay).SetEase(Ease).OnComplete(() => OnHide());
        }

        public override void Show(RectTransform transform)
        {
            transform.anchoredPosition = GetScreenPosition();
            transform.DOAnchorPos(Vector3.zero, Time).SetDelay(Delay).SetEase(Ease);
        }

        private Vector2 GetScreenPosition()
        {
            Vector2 screenPos;
            switch (From)
            {
                case ScreenPosition.Top:
                    screenPos = new Vector2(0, Screen.height);
                    break;
                case ScreenPosition.Bottom:
                    screenPos = new Vector2(0, Screen.height);
                    break;
                case ScreenPosition.Left:
                    screenPos = new Vector2(Screen.width, 0);
                    break;
                case ScreenPosition.Right:
                    screenPos = new Vector2(Screen.width, 0);
                    break;
                default:
                    screenPos = new Vector2(Screen.width, 0);
                    break;
            }
            return screenPos;
        }

        public enum ScreenPosition
        {
            Top,
            Bottom,
            Left,
            Right
        }
    }

    [System.Serializable]
    public class UIScaleAnimation : UIAnimation
    {
        [Range(0, 1)] public float From;

        public override void Hide(RectTransform transform)
        {            
            transform.DOScale(Vector3.zero,Time).SetDelay(Delay).SetEase(Ease).OnComplete(()=>OnHide());
        }

        public override void Show(RectTransform transform)
        {
            transform.localScale = Vector3.one * From;
            transform.DOScale(Vector3.one, Time).SetDelay(Delay).SetEase(Ease);
        }
    }

    [System.Serializable]
    public class UIFadeAnimation : UIAnimation
    {
        [Range(0, 1)] public float From;

        public override void Hide(RectTransform transform)
        {
            if (transform.GetComponent<CanvasGroup>()!=null)
            {
                transform.GetComponent<CanvasGroup>().DOFade(From, Time).SetEase(Ease);
            }            
        }

        public override void Show(RectTransform transform)
        {
            if (transform.GetComponent<CanvasGroup>() != null)
            {
                transform.GetComponent<CanvasGroup>().alpha = From;
                transform.GetComponent<CanvasGroup>().DOFade(1, Time).SetEase(Ease);
            }
        }
    }

}