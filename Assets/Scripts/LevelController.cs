using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int numberOfTries;
    
    private int currentTry;
    private int currentCharacter;

    [SerializeField] private List<CharacterData> scriptables;
    private AnswerResult[] results;
    

    public void ShuffleList()
    {
        scriptables.Shuffle();
    }

    public void GetNextCharacter()
    {
        currentTry = 0;

        currentCharacter++;
        if(currentCharacter>= scriptables.Count)
        {
            UIManager.Instance.SetGameResult(results);
            currentCharacter= 0;
            UIManager.Instance.ExitUIScreen(()=>GameManager.Instance.NextState());
        }
        else
        {
            UIManager.Instance.SetGameplayInitialInfo(scriptables[currentCharacter]);
        }
    }

    
    public void ProcessAnswer(JokeTheme answer1, JokeGenre answer2, string answer3)
    {
        currentTry++;
        AnswerResult result = new()
        {
            IsCorrectTheme = answer1 == scriptables[currentCharacter].CorrectJokeTheme,
            IsCorrectGenre = answer2 == scriptables[currentCharacter].CorrectJokeGenre,
            IsCorrectNoun = answer3 == scriptables[currentCharacter].CorrectNoun
        };

        UIManager.Instance.ShowJokeResult(result);

        if((result.IsCorrectNoun && result.IsCorrectGenre && result.IsCorrectTheme )|| currentTry == numberOfTries)
        {
            results[currentCharacter] = result;
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