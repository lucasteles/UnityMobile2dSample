using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnaFaca : MonoBehaviour
{
    public GameObject facaPrefab;
    public float CoolDownEmSegundos = 0;
    public float TempoPraDestruir = 0;

    public AudioClip som;
    public AudioSource audioSource;

    float tempoPassado = 0;
    Camera main;
    public bool stop;

    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop) return;
        Vector2? pos = null;
        if (Input.touchCount == 1)
        {
            var touch = Input.GetTouch(0);
            if ( touch.phase == TouchPhase.Began)
                pos = touch.position;
        }

        if (Input.GetMouseButtonDown(0))
            pos = Input.mousePosition;

        if (tempoPassado >= CoolDownEmSegundos && pos.HasValue)
        {
            var novaFaca = Instantiate(facaPrefab);
            audioSource.PlayOneShot(som);
            Destroy(novaFaca, TempoPraDestruir);
            var facaPos = main.ScreenToWorldPoint(pos.Value);
            facaPos.z = main.nearClipPlane;
            novaFaca.transform.position = facaPos;
            tempoPassado = 0;
        }

        tempoPassado += Time.deltaTime;
    }
}
