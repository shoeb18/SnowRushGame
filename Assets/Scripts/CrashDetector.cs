using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashFX;
    [SerializeField] AudioClip crashSFX;
    public PlayerController playerController;
    bool isDead = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && !isDead)
        {
            isDead = true;
            crashFX.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            playerController.enabled = false;
            Invoke("ReloadScene", 1f);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
