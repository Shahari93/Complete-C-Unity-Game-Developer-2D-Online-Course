using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] private int max;
    [SerializeField] private int min;
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] TMP_Text guessNumberText;
    [SerializeField] TMP_Text pickNumberText;
    private int myGuess;

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        max = Random.Range(1000, 2001);
        min = Random.Range(1, 101);
        CalcNewGuess();
        max += 1;
        pickNumberText.text = "Pick a number between " + min + " and " + max;
    }

    public void OnPressHigher()
    {
        min = myGuess + 1; // because the number that the player picked is higher then what the computer guessed, we set the min number to be the guess
        if (min >= max)
        {
            min = max;
        }
        CalcNewGuess();
    }

    public void OnPressLower()
    {
        CalcNewGuess();
        max = myGuess - 1; // because the number that the player picked is lower then what the computer guessed, we set the max number to be the guess
    }

    // after setting the max/min to what the computer guessed, we need to calc a new guess
    private void CalcNewGuess()
    {
        myGuess = Random.Range(min, max);
        guessNumberText.text = myGuess.ToString();
        if (min != myGuess || max != myGuess)
        {
            return;
        }
    }
}
