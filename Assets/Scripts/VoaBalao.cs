using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoaBalao : MonoBehaviour
{
    public float speed;
    public GameObject particles;
    public AudioClip burst;
    public Counter pontos;

    void Awake()
    {
        pontos = FindObjectOfType<Counter>();
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pontos.Add();
            GameObject.Find("Audio").GetComponent<AudioSource>().PlayOneShot(burst);
            var p = Instantiate(particles);
            p.transform.position = gameObject.transform.position;
            Destroy(gameObject);
            Destroy(p, 5);
        }
    }

}
