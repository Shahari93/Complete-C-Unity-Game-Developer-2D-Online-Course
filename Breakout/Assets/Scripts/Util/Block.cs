using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip blockAudioClip = null;
    [SerializeField] private GameObject particlesVFX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(blockAudioClip, Camera.main.transform.position, 1f);
        DisplayVFX();
        Destroy(this.gameObject);
    }

    private void DisplayVFX()
    {
        GameObject particles = Instantiate(particlesVFX, transform.position, transform.rotation);
        Destroy(particles, 2f);
    }
}
