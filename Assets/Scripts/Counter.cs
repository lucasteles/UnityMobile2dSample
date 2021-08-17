using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    int pontos = 0;
    public TMP_Text text;

    public void Add() => pontos++;
    void Update()
    {
        text.text = pontos.ToString();
    }
}
