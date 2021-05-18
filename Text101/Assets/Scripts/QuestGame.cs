using UnityEngine;
using UnityEngine.UI;

public class QuestGame : MonoBehaviour
{
    [SerializeField] Text textComponent; // a variable for the text component 
    [SerializeField] State startState; // Starting state
    private State state; // other states

    void Start()
    {
        state = startState; // setting the state to be the first state
        textComponent.text = state.GetStateStory(); // setting the text component from what we wrote in the SO, to be shown inside Unity
    }
}
