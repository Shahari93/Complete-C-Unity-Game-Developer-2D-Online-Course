using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip blockAudioClip = null;
    [SerializeField] private GameObject particlesVFX;
    LevelCheck level;

    [SerializeField] private int timesBlockHit = 0; // Only serialized for debug

    [SerializeField] private Sprite[] hitSprite;

    private void Start()
    {
        AddBreakableBlocks();
    }

    private void AddBreakableBlocks()
    {
        level = FindObjectOfType<LevelCheck>();
        if (gameObject.CompareTag("Breakable"))
        {
            level.AddBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Breakable"))
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesBlockHit++;
        int maxHits = hitSprite.Length + 1;
        if (timesBlockHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextSprite();
        }
    }

    private void ShowNextSprite()
    {
        int spriteToShow = timesBlockHit - 1;
        if (hitSprite[spriteToShow] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[spriteToShow];
        }
        else
        {
            Debug.LogError("Sprite is missing from block array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(blockAudioClip, Camera.main.transform.position, 1f);
        DisplayVFX();
        Destroy(this.gameObject);
        level.RemoveBlocks();
    }

    private void DisplayVFX()
    {
        GameObject particles = Instantiate(particlesVFX, transform.position, transform.rotation);
        Destroy(particles, 2f);
    }
}