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

    [SerializeField] private List<CharacterData> scriptables; 
    

    public void ShuffleList()
    {
        scriptables.Shuffle();
    }

    public void GetNextCharacter()
    {
        currentTry = 0;
        correctAnswers = 0;

        currentCharacter++;
        UIManager.Instance.SetGameplayInitialInfo(scriptables[currentCharacter]);
        if(currentCharacter>= scriptables.Count)
        {
            GameManager.Instance.NextState();
            currentCharacter= 0;
        }
    }

    
    public void ProcessAnswer(JokeTheme answer1, JokeGenre answer2, string answer3)
    {
        currentTry++;
        correctAnswers = 0;
        AnswerResult result = new AnswerResult();
        if(answer1 == scriptables[currentCharacter].CorrectJokeTheme)
        {
            correctAnswers++;
            result.IsCorrectTheme = true;
        }
        if(answer2== scriptables[currentCharacter].CorrectJokeGenre)
        {
            correctAnswers++;
            result.IsCorrectGenre = true;
        }
        if(answer3== scriptables[currentCharacter].CorrectNoun)
        {
            correctAnswers++;
            result.IsCorrectNoun = true;
        }

        UIManager.Instance.ShowJokeResult(result);

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
public struct AnswerResult
{
    public bool IsCorrectTheme;
    public bool IsCorrectGenre;
    public bool IsCorrectNoun;
}