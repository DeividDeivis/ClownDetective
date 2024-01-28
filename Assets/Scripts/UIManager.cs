using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> screens;

    [Header("UI Menu elements")]
    [SerializeField] private Image titleImg;
    [SerializeField] private Button playBtn;

    [Header("UI Gameplay elements")]
    [SerializeField] private Image playerImg;
    [SerializeField] private Image npcImg;
    [SerializeField] private List<Image> playerLifes;

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

    #region UI Menu
    private void EnterMenu() 
    { 

    }
    private void ExitMenu()
    {
    }
    #endregion

    #region UI Gameplay
    private void EnterGameplay() 
    { 

    }

    private void ExitGameplay()
    {

    }

    public void SetGameplayInitialInfo(CharacterData data) 
    {
        
    }
    #endregion

    #region UI Score
    private void EnterScore() 
    { 

    }
    private void ExitScore()
    {

    }
    #endregion
}
public enum UIState { Menu, Gameplay, Score }
