using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCheck : MonoBehaviour
{
    [SerializeField] List<Block> blocks = new List<Block>();
    [SerializeField] Object nextScene;

    private void Start()
    {
        blocks.AddRange(FindObjectsOfType<Block>());
    }

    private void Update()
    {
        CountBlocksInLevel();
    }


    private void CountBlocksInLevel()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            if (!blocks[i])
            {
                blocks.RemoveAt(i);
            }
            if (blocks.Count == 0)
            {
                SceneManager.LoadScene(nextScene.name);
            }
        }
    }
}
