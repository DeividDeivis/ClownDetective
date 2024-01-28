using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> screens;
    private Sequence animSequence;

    [Header("UI Menu elements")]
    [SerializeField] private TextMeshProUGUI titleImg;
    [SerializeField] private Image playBtn;

    [Header("UI Gameplay elements")]
    [SerializeField] private Image playerImg;
    [SerializeField] private Image npcImg;
    [SerializeField] private TextMeshProUGUI playerLifes;

    [Header("UI Score elements")]
    [SerializeField] private RectTransform papers;

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

    }

    public void SetGameplayInitialInfo(CharacterData data) // On Start Level
    {
        
    }

    public void ShowJokeResult(AnswerResult result) // On Finish Round
    {

    }

    public void SetGameResult(AnswerResult[] gameResults) // On Game Finish
    {

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
