using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

   public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // getting the current index

        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            currentSceneIndex = 0;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
