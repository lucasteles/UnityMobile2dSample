using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnaBalao : MonoBehaviour
{
    public Transform De;
    public Transform Até;
    public GameObject Balao;

    public float spawnRate;
    float spawnRatePassed;

    // Update is called once per frame
    void Update()
    {
        if (spawnRatePassed >= spawnRate)
        {
            var balao = Instantiate(Balao);
            Destroy(balao, 5);
            var novoX = Random.Range(De.transform.position.x, Até.transform.position.x);
            spawnRatePassed = 0;

            balao.transform.position = new Vector3(novoX, De.transform.position.y, transform.position.z);
        }

        spawnRatePassed += Time.deltaTime;
    }
}
