using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Barra : MonoBehaviour
{
    //componente de luz
    [SerializeField] private Light2D ligth2D;

    //Afecciones a la intensidad
    [SerializeField] private float afeccionGradualIntensidad;
    [SerializeField] private float intensidadMaxima;
    public float intensidadActual;
    [SerializeField] private float damageLight;

    //Afecciones al FallOff
    [SerializeField] private float afeccionGradualFallOff;
    [SerializeField] private float FallOffMaxima;
    public float FallOffActual;
    [SerializeField] private float damageFallOff;

    //Flag de "puede recibir daño"
    public bool canHurt = true;

    //Referencia a Destello
    public Destello destello;

    //-----------------------------------------------------------------------

    void Start()
    {

    }

    //-----------------------------------------------------------------------
    public void SetLightPropeties(Light2D luz, float maxIntensity, float maxFallOff)
    {
        ligth2D = luz;

        //Afecciones a la intensidad
        intensidadMaxima = maxIntensity;
        intensidadActual = intensidadMaxima;
        afeccionGradualIntensidad = intensidadMaxima / 100f;
        damageLight = afeccionGradualIntensidad * 2.5f;

        //Afecciones al FallOff
        FallOffMaxima = maxFallOff;
        FallOffActual = FallOffMaxima;
        afeccionGradualFallOff = FallOffMaxima / 100f;
        damageFallOff = afeccionGradualFallOff * 2.5f;
        //Iniciamos corutina para recibir daño
        StartCoroutine(TakeRepeatingDamage());
    }

    public void TakeDamage(float damageI, float damageF)
    {
        //Si despues de recibir daño aun nos queda vida, simplemente reducimos
        if (intensidadActual - damageI > 0)
        {
            intensidadActual -= damageI;
            FallOffActual += damageF;
        }

        //En caso de que el Daño conlleve a la muerte
        else
        {
            //Dejamos la vida en 0 de forma constante
            intensidadActual = 0;
            FallOffActual = 1;
            //GAME OVER
            // ()...
        }

        //Seteamos la proporción de la imagen que se muestra en base a la Vida restante
        ligth2D.intensity = intensidadActual / intensidadMaxima;
        ligth2D.falloffIntensity = FallOffActual;
    }

    //-----------------------------------------------------------------------

    public void MakeDamage()
    {
        TakeDamage(damageLight, damageFallOff);
    }
    public IEnumerator TakeRepeatingDamage()
    {
        //Mientras el Flag de "Puede recibir daño" este activa
        while(canHurt) 
        {
            //Tomamos el daño
            TakeDamage(afeccionGradualIntensidad, afeccionGradualFallOff);

            //Repetimos cada segundo
            yield return new WaitForSeconds(1f);
        }
    }


}
