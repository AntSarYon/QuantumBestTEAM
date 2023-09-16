using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirMouse : MonoBehaviour
{
    private void Update()
    {
        //Actualizamos constantemente su posicion con el mouse
        transform.position = new Vector2(
            Mathf.Clamp(MouseLimiter.Instance.CoorMouse.x, -1.738f, 1.744f),
            Mathf.Clamp(MouseLimiter.Instance.CoorMouse.y, -1.248f, 1.262f)
            );
            
    }
}
