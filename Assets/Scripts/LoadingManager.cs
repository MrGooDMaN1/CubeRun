using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;


public class LoadingManager : MonoBehaviour 
{
    public static LoadingManager Instance { get; private set; }

    private Animator _animator;

    private static float _minTimeLoading = 1f;
    private AsyncOperation _loadingOperation;
    private float _loadingTime = 0f;

    private void Awake()
    {
        Instance = this;

        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animator.SetTrigger("OpenScene");
    }

    public void ExitGame()
    {
        //_animator.SetTrigger("CloseScene");
        _animator.SetTrigger("ExitGame");
        Application.Quit();
    }

    public void LoadScene(int sceneIndex)
    {
        _animator.SetTrigger("CloseScene");

        StartCoroutine(ClosingAnimationEnd(sceneIndex));

    }

    private IEnumerator ClosingAnimationEnd(int sceneIndex)
    {
        Debug.Log("The first carutina works");

        while (!_animator.GetBool("CloseScene"))
            yield return null;

        if (sceneIndex < 0 || sceneIndex > SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.LogError($"You cannot load a scene with index {sceneIndex}");
        }
        else
        {
            _loadingOperation = SceneManager.LoadSceneAsync(sceneIndex);
            _loadingOperation.allowSceneActivation = false;

            StartCoroutine(ChangeSceneAfterMinLoadingTime());
        }
    }

    private IEnumerator ChangeSceneAfterMinLoadingTime()
    {
        Debug.Log("The second carutina works");
        while (_loadingTime < _minTimeLoading)
        {
            _loadingTime += Time.unscaledDeltaTime;
            yield return null;
        }

        _loadingOperation.allowSceneActivation = true;
    }
}
