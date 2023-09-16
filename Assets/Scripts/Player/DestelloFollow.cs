using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DestelloFollow : MonoBehaviour
{
    //Componente de Luz
    public Light2D destelloLight;

    //Tiempos de Luz
    public float tiempoDeCrecimiento = 0.5f;
    public float tiempoDeDecrecimiento = 2f;

    //Referencia a Barra de Vida
    public Barra barra;
    public float autoDamage;

    //Flag de Destello
    private bool estaDestellando = false;

    //Control de movimiento del jugador
    public FollowCamera followController;

    //Maximo brillo en seteado por defecto
    public float maxBright;

    //------------------------------------------------------

    private void Awake()
    {
        //Obtenemos referencia al FollowCamera de la particula
        followController = GetComponent<FollowCamera>();
    }

    //--------------------------------------------------------------------------

    void Update()
    {
        //Si se hace click, y no esta destellando
        if (Input.GetMouseButtonDown(0) && !estaDestellando)
        {
            barra.canHurt = false;
            barra.TakeDamage(autoDamage);
            StartCoroutine(RealizarDestello());

            //Desactivamos la capacidad de Seguir la camara
            followController.CanFollow = false;
        }
    }

    //--------------------------------------------------------------------------

    IEnumerator RealizarDestello()
    {
        estaDestellando = true;
        // Incrementar gradualmente el Radius y disminuir el FallOff Strength
        float tiempoPasado = 0f;
        float inicioRadius = destelloLight.pointLightOuterRadius;
        float inicioFallOff = destelloLight.falloffIntensity;
        while (tiempoPasado < tiempoDeCrecimiento)
        {
            tiempoPasado += Time.deltaTime;
            float progreso = tiempoPasado / tiempoDeCrecimiento;
            destelloLight.pointLightOuterRadius = Mathf.Lerp(0f, maxBright, progreso);
            destelloLight.falloffIntensity = Mathf.Lerp(1f, 0.5f, progreso);
            yield return null;
        }

        // Esperar 0.5 segundos
        yield return new WaitForSeconds(0.5f);

        // Decrementar gradualmente el Radius y aumentar el FallOff Strength
        tiempoPasado = 0f;
        while (tiempoPasado < tiempoDeDecrecimiento)
        {
            tiempoPasado += Time.deltaTime;
            float progreso = tiempoPasado / tiempoDeDecrecimiento;
            destelloLight.pointLightOuterRadius = Mathf.Lerp(maxBright, 0f, progreso);
            destelloLight.falloffIntensity = Mathf.Lerp(0.5f, 1f, progreso);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        estaDestellando = false;
        barra.canHurt = true;

        //Activamos de vuelta la capacidad de Seguir la camara
        followController.CanFollow = true;

        StartCoroutine(barra.TakeRepeatingDamage());
        CollectorManager.ChangePrefabPositions();
    }
}
