using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private JokeConstructorController jokeController;
    [SerializeField] private List<GameObject> screens;
    private Sequence animSequence;
    private CharacterData currentData;

    [Header("UI Menu elements")]
    [SerializeField] private TextMeshProUGUI titleImg;
    [SerializeField] private Image playBtn;

    [Header("UI Gameplay elements")]
    [SerializeField] private Image playerImg;
    [SerializeField] private Image npcImg;
    [SerializeField] private TextMeshProUGUI playerAttempts;
    [SerializeField] private FileInfoController FileData;
    [SerializeField] private Image dialog;
    private int Attempts = 1;

    [Header("UI Score elements")]
    [SerializeField] private RectTransform papers;
    [SerializeField] private TextMeshProUGUI perfromanceScoreTMP;

    [SerializeField] private UIState currentUIState;
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUIState(UIState state) 
    {
        currentUIState = state;
        switch (currentUIState) 
        {
            case UIState.Menu: EnterMenu(); SetScreen(0); break;
            case UIState.Gameplay: EnterGameplay(); SetScreen(1); break;
            case UIState.Score: EnterScore(); SetScreen(2); break;
        }
    }

    private void SetScreen(int index) 
    {
        foreach (var screen in screens)
            screen.SetActive(false);
        screens[index].SetActive(true);
    }

    public void ExitUIScreen(Action onComplete = null) 
    {
        StartCoroutine(ExitAnim(onComplete));
    }

    private IEnumerator ExitAnim(Action onComplete = null) 
    {
        animSequence.PlayBackwards();
        yield return new WaitForSeconds(animSequence.Duration());
        onComplete?.Invoke();
        animSequence.Kill();
        animSequence = null;
    }

    #region UI Menu
    private void EnterMenu() 
    {
        titleImg.rectTransform.localScale = Vector3.one * .5f;
        titleImg.color = new Color(titleImg.color.r, titleImg.color.g, titleImg.color.b, 0f);
        playBtn.rectTransform.localScale = Vector3.one * .5f;
        playBtn.color = new Color(playBtn.color.r, playBtn.color.g, playBtn.color.b, 0f);

        animSequence = DOTween.Sequence().SetAutoKill(false)
            .Append(ScaleAnim(titleImg.rectTransform, Vector3.one * 1.1f, .15f).SetEase(Ease.Linear))
            .Join(FadeAnim(titleImg.rectTransform, .13f).SetEase(Ease.Linear))
            .Append(ScaleAnim(titleImg.rectTransform, Vector3.one, .15f).SetEase(Ease.Linear))

            .Append(ScaleAnim(playBtn.GetComponent<RectTransform>(), Vector3.one * 1.1f, .15f).SetEase(Ease.Linear))
            .Join(FadeAnim(playBtn.GetComponent<RectTransform>(), .13f).SetEase(Ease.Linear))
            .Append(ScaleAnim(playBtn.GetComponent<RectTransform>(), Vector3.one, .15f).SetEase(Ease.Linear));
    }
    #endregion

    #region UI Gameplay
    private void EnterGameplay() 
    {
        playerImg.rectTransform.localPosition = new Vector2(-1145, 0);
        npcImg.rectTransform.localPosition = new Vector2(1370, 0);
        FileData.GetComponent<RectTransform>().localPosition = new Vector2(0, 900);
    }

    public void SetGameplayInitialInfo(CharacterData data) // On Start Level
    {
        currentData = data;

        Attempts = 1;
        playerAttempts.text = $"Intento {Attempts}/3";

        FileData.SetFileInfo(currentData);
        npcImg.sprite = currentData.Normal;

        playerImg.rectTransform.localPosition = new Vector2(-1145, 0);
        npcImg.rectTransform.localPosition = new Vector2(1370, 0);

        jokeController.SetNouns(currentData.Nouns);
        StartCoroutine(StartGameplayAnim());
    }

    private IEnumerator StartGameplayAnim()
    {
        FromAnim(playerImg.rectTransform, new Vector2(-700, 0), .3f).SetEase(Ease.Linear);
        FromAnim(npcImg.rectTransform, new Vector2(756, 0), .3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(3);
        FromAnim(playerImg.rectTransform, new Vector2(-1145, 0), .3f).SetEase(Ease.Linear);
        FromAnim(npcImg.rectTransform, new Vector2(1370, 0), .3f).SetEase(Ease.Linear);
        playerImg.DOFade(0f, .3f);
        npcImg.DOFade(0f, .3f);
        yield return new WaitForSeconds(1);
        playerImg.rectTransform.localPosition = new Vector2(-1145, -290);
        npcImg.rectTransform.localPosition = new Vector2(1370, -241);
        animSequence = DOTween.Sequence().SetAutoKill(false)
            .Append(FadeAnim(playerImg.rectTransform, .3f))
            .Join(FadeAnim(npcImg.rectTransform, .3f))
            .Append(FromAnim(playerImg.rectTransform, new Vector2(-700, -290), .3f).SetEase(Ease.Linear))
            .Join(FromAnim(npcImg.rectTransform, new Vector2(756, -241), .3f).SetEase(Ease.Linear))
            .Append(FromAnim(FileData.GetComponent<RectTransform>(), new Vector2(0, 60), .3f));
    }

    public void ShowJokeResult(AnswerResult result) // On Finish Round
    {
        if(result.IsCorrectTheme && result.IsCorrectGenre && result.IsCorrectNoun)
            npcImg.sprite = currentData.Laugh;
        else if(result.IsCorrectTheme || result.IsCorrectGenre || result.IsCorrectNoun)
            npcImg.sprite = currentData.Smile;
        else if (!result.IsCorrectTheme || !result.IsCorrectGenre || !result.IsCorrectNoun) 
        {
            Attempts++;
            Attempts = Mathf.Clamp(Attempts, 1, 3);
        }            
       
        playerAttempts.text = $"Intento {Attempts}/3";
    }

    public void SetGameResult(AnswerResult[] gameResults) // On Game Finish
    {
        float score = 0;
        foreach(AnswerResult result in gameResults)
        {
            if(result.IsCorrectGenre && result.IsCorrectNoun && result.IsCorrectTheme)
            {
                score += (100f / 3f) * ((4-result.tryNumber) / 3f);
            }
        }
        perfromanceScoreTMP.text = Mathf.Round(score).ToString()+"%";
    }
    #endregion

    #region UI Score
    private void EnterScore() 
    { 

    }
    #endregion

    #region Animations
    public static Tween FadeAnim(RectTransform element, float time)
    {
        if (element.GetComponent<Image>()) return DOTween.Sequence().Join(element.GetComponent<Image>().DOFade(1, time));
        else if (element.GetComponent<TextMeshProUGUI>()) return DOTween.Sequence().Append(element.GetComponent<TextMeshProUGUI>().DOFade(1, time));
        else if (element.GetComponent<CanvasGroup>()) return DOTween.Sequence().Append(element.GetComponent<CanvasGroup>().DOFade(1, time));
        else return null;
    }

    public static Tween ScaleAnim(RectTransform element, Vector3 finalScale, float time)
    {
        return element.DOScale(finalScale, time);
    }

    public static Tween FromAnim(RectTransform element, Vector2 finalPos, float time)
    {
        return element.DOAnchorPos(finalPos, time);
    }

    public static Tween FillAmountAnim(RectTransform element, float time)
    {
        return element.GetComponent<Image>().DOFillAmount(1, time);
    }
    #endregion
}
public enum UIState { Menu, Gameplay, Score }
