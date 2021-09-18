using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTrigger : MonoBehaviour
{
    //Loading a scene with draging and droping the scene object from the project window
    [SerializeField] private Object sceneObjectToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(sceneObjectToLoad.name);
        GameStatus.gameStatus.RestartScoreOnNextSession(); // Destroing so the score won't follow when starting the new scene
    }
}