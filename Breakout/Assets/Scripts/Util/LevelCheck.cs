using System.Collections.Generic;
using UnityEngine;

public class LevelCheck : MonoBehaviour
{
    [SerializeField] List<Block> blocks = new List<Block>();
    SceneLoader sceneLoader;

    private void Start()
    {
        blocks.AddRange(FindObjectsOfType<Block>());
        sceneLoader = FindObjectOfType<SceneLoader>();
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
                sceneLoader.LoadNextScene();
            }
        }
    }
}