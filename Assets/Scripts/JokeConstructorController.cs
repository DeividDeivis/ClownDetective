using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JokeConstructorController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI theme;
    [SerializeField]
    private TextMeshProUGUI genre;
    [SerializeField]
    private TextMeshProUGUI noun;

    [SerializeField]
    private Button upTheme, downTheme;
    [SerializeField]
    private Button upGenre, downGenre;
    [SerializeField]
    private Button upNoun, downNoun;
    [SerializeField]
    private Button sendJokeButton;

    private List<string> characterNouns;

    private int currentTheme;
    private int currentGenre;
    private int currentNounIndex;
    private string currentNoun;

    LevelController levelController;

    #region UI

    #endregion

    #region behaviour
    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        upTheme.onClick.AddListener(() => ChangeTheme(true));
        upGenre.onClick.AddListener(() => ChangeGenre(true));
        upNoun.onClick.AddListener(() => ChangeNoun(true));
        downTheme.onClick.AddListener(() => ChangeTheme(false));
        downGenre.onClick.AddListener(() => ChangeGenre(false));
        downNoun.onClick.AddListener(() => ChangeNoun(false));
        sendJokeButton.onClick.AddListener(() => levelController.ProcessAnswer((JokeTheme)currentTheme, (JokeGenre)currentGenre, currentNoun));

    }
    private void ChangeTheme(bool changingUp)
    {
        //TODO: Revisar que la adicion y substraccion se hagan en este frame y no en el siguiente
        currentTheme = changingUp ?
            (currentTheme == 0 ? (int)JokeTheme.Familia : --currentTheme) :
            (currentTheme == 5 ? (int)JokeTheme.Politica : ++currentTheme);
        RefresUI();
    }
    private void ChangeGenre(bool changingUp)
    {
        currentGenre = changingUp ?
            (currentGenre == 0 ? (int)JokeGenre.DadJoke : --currentGenre) :
            (currentGenre == 5 ? (int)JokeGenre.negro : ++currentGenre);
        RefresUI();
    }
    private void ChangeNoun(bool changingUp)
    {
        currentNounIndex = changingUp ?
            (currentNounIndex == 0 ? characterNouns.Count - 1 : --currentNounIndex) :
            (currentNounIndex == characterNouns.Count - 1 ? 0 : ++currentNounIndex);
        currentNoun = characterNouns[currentNounIndex];

        RefresUI();
    }

    private void RefresUI()
    {
        theme.text = ((JokeTheme)currentTheme).ToString();
        genre.text = "Humor "+((JokeGenre)currentGenre).ToString();
        noun.text = currentNoun;
    }

    public void SetCorrectAnswers(AnswerResult result)
    {
        if(result.IsCorrectTheme)
        {
            upTheme.interactable= false;
            downTheme.interactable= false;
            theme.color = Color.green;
        }
        if(result.IsCorrectGenre)
        {
            upGenre.interactable= false;
            downTheme.interactable= false;
            genre.color = Color.green;
        }
        if(result.IsCorrectNoun)
        {
            upNoun.interactable= false;
            downNoun.interactable= false;
            noun.color = Color.green;
        }
    }

    public void ResetStatus()
    {
        upTheme.interactable = true;
        downTheme.interactable = true;
        upGenre.interactable = true;
        downTheme.interactable = true;
        upNoun.interactable = true;
        downNoun.interactable = true;
        theme.color = Color.black;
        genre.color = Color.black;
        noun.color = Color.black;
    }

    public void SetNouns(List<string> nouns)
    {        
        ResetStatus();
        characterNouns = new List<string>(nouns);
        currentNoun = characterNouns[0];
        RefresUI();
    }
    #endregion

}
