using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Go;
    public AudioClip Som;

    bool cabou = false;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Balloon") || cabou) return;
        FindObjectOfType<SpawnaBalao>().spawnRate = float.MaxValue;
        FindObjectOfType<SpawnaFaca>().stop = cabou = true;;
        GameObject.Find("Audio").GetComponent<AudioSource>().PlayOneShot(Som);

        Go.SetActive(true);
    }

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
