using System;
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

    private void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = state.GoToNextState();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeStateAndShowText(0, nextStates);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeStateAndShowText(1, nextStates);
        }

        if (nextStates.Length <= 2)
        {
            return;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeStateAndShowText(2, nextStates);
            }
        }
    }

    // A method that have 2 parameters. One is the state num, and the second is the states array
    private void ChangeStateAndShowText(int stateNum, State[] nextStates)
    {
        state = nextStates[stateNum];
        textComponent.text = state.GetStateStory();
    }

}
