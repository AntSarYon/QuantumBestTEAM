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
    public Barra barra;
    public float autoDamage;

    //Flag de Destello
    private bool estaDestellando = false;

    //--------------------------------------------------------------------------

    void Update()
    {
        //Si se hace click, y no se esta destellando
        if (Input.GetMouseButtonDown(0) && !estaDestellando)
        {
            barra.canHurt = false;
            barra.TakeDamage(autoDamage);
            StartCoroutine(RealizarDestello());
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
            destelloLight.pointLightOuterRadius = Mathf.Lerp(0f, 10f, progreso);
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
            destelloLight.pointLightOuterRadius = Mathf.Lerp(10f, 0f, progreso);
            destelloLight.falloffIntensity = Mathf.Lerp(0.5f, 1f, progreso);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        estaDestellando = false;
        barra.canHurt = true;
        StartCoroutine(barra.TakeRepeatingDamage());
        CollectorManager.ChangePrefabPositions();
    }
}
