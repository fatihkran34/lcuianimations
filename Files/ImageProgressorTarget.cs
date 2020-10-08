using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LCUI
{
    public class ImageProgressorTarget : ProgressorTarget
    {
        [SerializeField] private Image image;

        private void Awake()
        {
            if (image==null)
            {
                image = GetComponent<Image>();
            }
        }

        public override void SetValue(float value)
        {
            image.fillAmount = value;
        }
    }
}