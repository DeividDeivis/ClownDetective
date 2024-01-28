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

    private List<string> characterNouns;

    private int currentTheme;
    private int currentGenre;
    private string currentNoun;

    #region UI

    #endregion

    #region behaviour
    private void Start()
    {
        upTheme.onClick.AddListener(() => ChangeTheme(true));
        upGenre.onClick.AddListener(() => ChangeGenre(true));
        upNoun.onClick.AddListener(() => ChangeNoun(true));
        upTheme.onClick.AddListener(() => ChangeTheme(false));
        upGenre.onClick.AddListener(() => ChangeGenre(false));
        upNoun.onClick.AddListener(() => ChangeNoun(false));
    }
    private void ChangeTheme(bool changingUp)
    {
        //TODO: Revisar que la adicion y substraccion se hagan en este frame y no en el siguiente
        currentTheme = changingUp ?
            (currentTheme == 0 ? (int)JokeTheme.PR : --currentTheme) :
            (currentTheme == 5 ? (int)JokeTheme.Politics : ++currentTheme);
        RefresUI();
    }
    private void ChangeGenre(bool changingUp)
    {
        currentGenre = changingUp ?
            (currentTheme == 0 ? (int)JokeGenre.Dad_joke : --currentTheme) :
            (currentTheme == 5 ? (int)JokeGenre.Humor_negro : ++currentTheme);
        RefresUI();
    }
    private void ChangeNoun(bool changingUp)
    {
        currentNoun = changingUp ?
            (currentTheme == 0 ? characterNouns[characterNouns.Count - 1] : characterNouns[--currentTheme]) :
            (currentTheme == 5 ? characterNouns[0] : characterNouns[++currentTheme]);

        RefresUI();
    }

    private void RefresUI()
    {
        theme.text = currentTheme.ToString();
        genre.text = currentGenre.ToString();
        noun.text = currentNoun;
    }

    public void SetNouns(List<string> nouns)
    {
        characterNouns = new List<string>(nouns);
    }
    #endregion

}
