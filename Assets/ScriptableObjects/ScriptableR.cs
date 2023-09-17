using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu (fileName = "Recuerdo",  menuName = "Tipo de recuerdo")]
public class ScriptableR : ScriptableObject
{
    public int ID_recuerdo;
    public string TituloRecuerdo;
    public string DescripcionRecuerdo;
    public bool activado = false;
    public AudioClip clipRecuerdo;
}
