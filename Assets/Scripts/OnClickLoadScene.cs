using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OnClickLoadScene : MonoBehaviour
{
    [SerializeField][Tooltip("The button that allows you to exit the game")] private Button _exitButton;
    [SerializeField] [Tooltip("The button that enables the transition to another scene")] private Button _activateButton;
    [SerializeField] [Tooltip("The index of the scene to go to when you click on the button")] private int _sceneIndex;

    private void Awake()
    {
        if(_activateButton == null)
        {
            if(!TryGetComponent(out _activateButton))
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
        bool activeButtonEnabledState = _activateButton.enabled;
        _activateButton.enabled = true;
        _exitButton.onClick.AddListener(LoadingManager.Instance.ExitGame);
        _activateButton.onClick.AddListener(() => LoadingManager.Instance.LoadScene(_sceneIndex));
        _activateButton.enabled = activeButtonEnabledState;

    }
}
