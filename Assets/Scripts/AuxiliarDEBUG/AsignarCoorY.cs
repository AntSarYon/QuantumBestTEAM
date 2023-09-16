using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsignarCoorY : MonoBehaviour
{

    void Update()
    {
        GetComponent<Text>().text = "Y: " + MouseLimiter.Instance.CoorMouse.y.ToString();

    }
}
