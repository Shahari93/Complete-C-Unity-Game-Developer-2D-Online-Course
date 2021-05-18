using UnityEngine;

/// <summary>
/// This is our scriptable object
/// Here we control what story text each state will show, and what are the next states we can go to from the current state
/// </summary>

// This is how we can create a ScriptableObject in Unity editor
[CreateAssetMenu(fileName = "States", menuName = "State")]
public class State : ScriptableObject // In order to have a ScriptableObject we need to dirive from ScriptableObject and not MonoBehaviour
{
    [TextArea(10, 14)] [SerializeField] string storyText; // variable where we enter our state text
    [SerializeField] State[] nextStates; // array that holds every next state 


    // a public method that return the state text and show it in Unity
    public string GetStateStory()
    {
        return storyText;
    }

    // a public method that return the next states array 
    public State[] GoToNextState()
    {
        return nextStates;
    }
}
