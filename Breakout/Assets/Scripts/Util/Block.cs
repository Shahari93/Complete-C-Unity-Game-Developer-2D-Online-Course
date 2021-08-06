using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip blockAudioClip = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(blockAudioClip, Camera.main.transform.position, 1f);
        Destroy(this.gameObject);
    }
}
