using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFloors : MonoBehaviour
{
    public Camera floor1Cam;
    public Camera floor2Cam;

    public void toggle()
    {
        floor1Cam.gameObject.SetActive(!floor1Cam.gameObject.activeSelf);
        floor2Cam.gameObject.SetActive(!floor2Cam.gameObject.activeSelf);
    }
}
