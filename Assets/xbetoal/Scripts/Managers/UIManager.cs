using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance 
    { 
        get => FindObjectOfType<UIManager>(); 
    }

    private int score;
    private GameObject _gameRef;

    [Space(10)]
    [SerializeField] GameObject menu;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject game;
    [SerializeField] GameObject result;

    private void Awake()
    {
        OverZone.OnCollisisonEnter += () =>
        {
            if (_gameRef)
            {
                Destroy(_gameRef);
            }

            game.SetActive(false);
            result.SetActive(true);

            if(SettingsManager.VibraEnbled)
            {
                Handheld.Vibrate();
            }
        };
    }


    private void Start()
    {
        OpenMenu();
    }

    public void StartGame()
    {
        var _parent = GameObject.Find("Environment").transform;
        var _prefab = Resources.Load<GameObject>("level");

        _gameRef = Instantiate(_prefab, _parent);

        result.SetActive(false);
        menu.SetActive(false);

        game.SetActive(true);
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void OpenMenu()
    {
        if (_gameRef)
        {
            Destroy(_gameRef);
        }

        game.SetActive(false);
        settings.SetActive(false);
        result.SetActive(false);

        menu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
