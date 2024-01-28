using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int numberOfTries;
    
    private int currentTry;
    private int correctAnswers;
    private int currentCharacter;

    private int correctAnswer1;
    private int correctAnswer2;
    private int correctAnswer3;

    [SerializeField] private List<string> scriptables; //TODO reemplazar por la lista de scriptables posta
    

    public void ShuffleList()
    {
        scriptables.Shuffle();
    }

    public void GetNextCharacter()
    {
        currentTry = 0;
        correctAnswers = 0;

        currentCharacter++;
        if(currentCharacter>= scriptables.Count)
        {
            GameManager.Instance.NextState();
            currentCharacter= 0;
        }
    }

    public void ProcessAnswer(int answer1, int answer2, int answer3)
    {
        currentTry++;
        correctAnswers = 0;
        if(answer1== correctAnswer1)
        {
            correctAnswers++;
        }
        if(answer2== correctAnswer2)
        {
            correctAnswers++;
        }
        if(answer3== correctAnswer3)
        {
            correctAnswers++;
        }

        if(correctAnswers ==3)
        {
            GetNextCharacter();
            return;
        }

        if(currentTry==numberOfTries)
        {
            GetNextCharacter();
        }
        
    }

}
