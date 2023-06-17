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


    private void Start()
    {
        OpenMenu();
    }

    public void StartGame()
    {
        var _parent = GameObject.Find("Environment").transform;
        var _prefab = Resources.Load<GameObject>("level");

        _gameRef = Instantiate(_prefab, _parent);

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

        menu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
