using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Cinemachine;

public class PlayerLogic : MonoBehaviour
{
    public Light2D luz;
    public CinemachineVirtualCamera virtualCamera;

    public float minOrtographicSize = 2f;
    public float maxOrtographicSize = 10f;

    private float velocidadCambio;

    void Start()
    {
        // Calcular la velocidad de cambio para que se cumplan los valores deseados
        float deltaSize = maxOrtographicSize - minOrtographicSize;
        float deltaIntensity = 1f - 0f;
        velocidadCambio = deltaIntensity / deltaSize;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Cambiar la intensidad de la luz.
        luz.intensity = Mathf.Clamp01(luz.intensity + scroll * velocidadCambio);

        // Cambiar el tamaño ortográfico de la cámara.
        float newSize = Mathf.Clamp(virtualCamera.m_Lens.OrthographicSize - scroll, minOrtographicSize, maxOrtographicSize);
        virtualCamera.m_Lens.OrthographicSize = newSize;
    }
}
