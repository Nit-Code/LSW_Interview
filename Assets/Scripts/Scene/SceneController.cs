using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    /// <summary>
    /// This code is (mostly) taken from a previous project I worked on
    /// </summary>

    [SerializeField] private SceneName _startingSceneName;
    [SerializeField] private Vector3 _startingPosition;

    private IEnumerator Start()
    {
        yield return StartCoroutine(LoadSceneAndSetActive(_startingSceneName));
    }

    public void LoadScene(SceneName sceneName, Vector3 spawnPosition) // If there's time, switch to scriptableObjects for scene data. Add black screen with related events while it is loading each scene
    {
        StartCoroutine(SwitchScenes(sceneName, spawnPosition));
    }

    private IEnumerator SwitchScenes(SceneName sceneName, Vector3 spawnPosition) 
    {
        if(sceneName == SceneName.NULL)
            yield return null;

        Player.Instance.gameObject.transform.position = spawnPosition;

        EventHandler.CallBeforeSceneUnloadEvent();

        // Unload current active scene
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        yield return StartCoroutine(LoadSceneAndSetActive(sceneName));
    }

    private IEnumerator LoadSceneAndSetActive(SceneName sceneName)
    {
        // Additive adds the scene our persistent scene, or whichever scene is active and loaded.
        yield return SceneManager.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Additive);

        // SceneManager.sceneCount - 1 is the most recently loaded scene
        Scene newlyLoadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);

        SceneManager.SetActiveScene(newlyLoadedScene);

        EventHandler.CallAfterSceneLoadEvent();
    }
}
