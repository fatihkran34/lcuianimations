using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LCUI
{
    public abstract class ProgressorTarget : MonoBehaviour
    {
        public abstract void SetValue(float value);
    }
}