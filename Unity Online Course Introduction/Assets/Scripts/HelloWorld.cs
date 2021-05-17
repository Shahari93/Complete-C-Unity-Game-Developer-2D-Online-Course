using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] private string yourName;

    void Start()
    {
        print("Hello " + yourName);
    }
}
