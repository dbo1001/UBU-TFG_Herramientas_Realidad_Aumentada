/*===============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================
Script del Vuforia engine 8.5.1
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluarTarget : MonoBehaviour
{
    public Image[] LowMedHigh;

    void SetMeter(Color low, Color med, Color high)
    {
        if (LowMedHigh.Length == 3)
        {
            if (LowMedHigh[0])
                LowMedHigh[0].color = low;
            if (LowMedHigh[1])
                LowMedHigh[1].color = med;
            if (LowMedHigh[2])
                LowMedHigh[2].color = high;
        }
    }

    public void SetQuality(Vuforia.ImageTargetBuilder.FrameQuality quality)
    {
        if (quality == null)
        {
            Debug.Log("No detecta la calidad");
        }
        switch (quality)
        {
            case (Vuforia.ImageTargetBuilder.FrameQuality.FRAME_QUALITY_NONE):
                SetMeter(Color.gray, Color.gray, Color.gray);
                break;
            case (Vuforia.ImageTargetBuilder.FrameQuality.FRAME_QUALITY_LOW):
                SetMeter(Color.red, Color.gray, Color.gray);
                break;
            case (Vuforia.ImageTargetBuilder.FrameQuality.FRAME_QUALITY_MEDIUM):
                SetMeter(Color.red, Color.yellow, Color.gray);
                break;
            case (Vuforia.ImageTargetBuilder.FrameQuality.FRAME_QUALITY_HIGH):
                SetMeter(Color.red, Color.yellow, Color.green);
                break;
        }
    }
}
