using System.Collections.Generic;
using UnityEngine;

public class LevelCheck : MonoBehaviour
{
    //[SerializeField] List<Block> blocks = new List<Block>();
    SceneLoader sceneLoader;
    int blocks;

    private void Start()
    {

        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void Update()
    {
        CountBlocksInLevel();
    }

    public void AddBlocks()
    {
        blocks++;
    }

    public void RemoveBlocks()
    {
        blocks--;
    }


    private void CountBlocksInLevel()
    {
        if(blocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
        //for (int i = 0; i < blocks.Count; i++)
        //{
        //    if (!blocks[i])
        //    {
        //        blocks.RemoveAt(i);
        //    }
        //    if (blocks.Count == 0)
        //    {
        //        sceneLoader.LoadNextScene();
        //    }
        //}
    }
}