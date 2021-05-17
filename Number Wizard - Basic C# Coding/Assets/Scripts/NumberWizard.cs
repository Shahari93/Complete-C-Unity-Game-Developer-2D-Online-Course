using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    private int myGuess;
    private int max;
    private int min;

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        max = 1000;
        min = 1;
        myGuess = 500;
        Debug.Log("Hello there stranger, and welcome to the wizard lair");
        Debug.Log("Pick any number between");
        Debug.Log("The highest number is: " + max);
        Debug.Log("The highest number is: " + min);
        Debug.Log("Tell me if your number is higher or lower than " + myGuess);
        Debug.Log("Up arrow = higher, Down arrow = Lower, Enter key = Correct");
        max += 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = myGuess; // because the number that the player picked is higher then what the computer guessed, we set the min number to be the guess
            CalcNewGuess();

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = myGuess; // because the number that the player picked is lower then what the computer guessed, we set the max number to be the guess
            CalcNewGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("I guessed your number! I'm the best");
            StartGame();
        }
    }

    // after setting the max/min to what the computer guessed, we need to calc a new guess
    private void CalcNewGuess()
    {
        myGuess = (max + min) / 2;
        Debug.Log("Is your number higher than " + myGuess + "?");
    }
}
