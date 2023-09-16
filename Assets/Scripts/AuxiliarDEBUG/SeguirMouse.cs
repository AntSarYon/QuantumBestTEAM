using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirMouse : MonoBehaviour
{
    private void Update()
    {
        //Actualizamos constantemente su posicion con el mouse
        transform.position = MouseLimiter.Instance.CoorMouse;
    }
}
