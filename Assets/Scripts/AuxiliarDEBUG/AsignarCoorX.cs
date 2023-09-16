using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsignarCoorX : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "X: " + MouseLimiter.Instance.CoorMouse.x.ToString();
    }
}
