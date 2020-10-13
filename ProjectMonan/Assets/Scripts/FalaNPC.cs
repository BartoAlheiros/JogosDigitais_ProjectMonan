using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FalaNPC : ScriptableObject
{
    // o que o NPC fala
    public string fala;

    // respostas possíveis
    public Resposta[] respostas;
}
