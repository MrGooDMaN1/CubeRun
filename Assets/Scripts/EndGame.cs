using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{
    [SerializeField][Tooltip("The button that allows you to exit the game")] private Button _exiMenutButton;
    [SerializeField][Tooltip("The button that enables the transition to another scene")] private Button _nextLevelButton;
    [SerializeField][Tooltip("The index of the scene to go to when you click on the button")] private int _sceneIndex;

    private void Awake()
    {
        if (_nextLevelButton == null)
        {
            if (!TryGetComponent(out _nextLevelButton))
            {
                Debug.LogError($"You dont have button on {name}");
                return;
            }
        }

        if (_sceneIndex < 0 || _sceneIndex > SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.LogError($"You cannot load a scene with index {_sceneIndex}");
        }
    }
    private void Start()
    {
        bool activeButtonEnabledState = _nextLevelButton.enabled;
        _nextLevelButton.enabled = true;
        _exiMenutButton.onClick.AddListener(() => LoadingManager.Instance.LoadScene(0));
        _nextLevelButton.onClick.AddListener(() => LoadingManager.Instance.LoadScene(_sceneIndex));
        _nextLevelButton.enabled = activeButtonEnabledState;

    }

    public GameManager gameManager;
    private void OnTriggerEnter()
    {
        gameManager.CompleteLevel();
    }


}
