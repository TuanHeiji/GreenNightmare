using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Milk"))
        {
            Destroy(collision.gameObject);
            audioManager.PlayItemSound();
            gameManager.AddScore(1);
        }

        else if (collision.CompareTag("Enemy"))
        {
            audioManager.PlayGameOverSound();
            gameManager.GameOver();
        }

        else if (collision.CompareTag("Trap"))
        {
            audioManager.PlayGameOverSound();
            gameManager.GameOver();
        }

        else if (collision.CompareTag("DiePoint"))
        {
            audioManager.PlayGameOverSound();
            gameManager.GameOver();
        }

        else if (collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            audioManager.PlayGameWinSound();
            gameManager.GameWin();
        }
    }
}
