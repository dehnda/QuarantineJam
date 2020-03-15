using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsUI : MonoBehaviour
{

    [SerializeField]
    private Image Filled = null;

    public void SetPoints(float points)
    {
        Filled.fillAmount = (points / 100);
    }
}
