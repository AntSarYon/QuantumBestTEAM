using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Destello : MonoBehaviour
{
    //Componente de Luz
    public Light2D destelloLight;

    //Tiempos de Luz
    public float tiempoDeCrecimiento = 0.5f;
    public float tiempoDeDecrecimiento = 2f;

    //Referencia a Barra de Vida
    public Barra energia;

    //Flag de Destello
    private bool estaDestellando = false;

    //Control de movimiento del jugador
    public PlayerMovement playerMovement;

    //Maximo brillo en seteado por defecto
    public float maxBright;
    public float maxFallOff;


    //--------------------------------------------------------------------------

    private void Awake()
    {
        energia.SetLightPropeties(destelloLight, maxBright, maxFallOff);
    }

    private void Update()
    {
        //Si se hace click, y no se esta destellando
        if (Input.GetMouseButtonDown(0) && !estaDestellando)
        {
            energia.canHurt = false;
            energia.MakeDamage();
            StartCoroutine(RealizarDestello());
            playerMovement.canWalk = false;
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
            destelloLight.pointLightOuterRadius = Mathf.Lerp(0f, energia.intensidadActual, progreso);
            destelloLight.falloffIntensity = Mathf.Lerp(1f, energia.FallOffActual, progreso);
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
            destelloLight.pointLightOuterRadius = Mathf.Lerp(energia.intensidadActual, 0f, progreso);
            destelloLight.falloffIntensity = Mathf.Lerp(energia.FallOffActual, 1f, progreso);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        estaDestellando = false;
        energia.canHurt = true;
        playerMovement.canWalk = true;
        StartCoroutine(energia.TakeRepeatingDamage());
        CollectorManager.ChangePrefabPositions();
    }
}
