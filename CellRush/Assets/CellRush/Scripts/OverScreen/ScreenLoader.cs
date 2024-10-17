
using UnityEngine;
using System;
using MoreMountains.Feedbacks;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;

public class ScreenLoader : MonoBehaviour
{
    [SerializeField] public MMF_Player feedbackIn;
     [SerializeField] public MMF_Player feedbackOut;
    [SerializeField, ReadOnly] private Enums.SubScenes currentScene;
    [SerializeField, ReadOnly] private Enums.SubScenes sceneToChangeTo;

    void Start()
    {
        Out();
    }

    void In()
    {
        feedbackIn?.PlayFeedbacks();
    }

    void Out()
    {
        feedbackOut?.PlayFeedbacks();
    }

    public void ChangeScene(Enums.SubScenes scene)
    {
        if (scene == currentScene) return;
        sceneToChangeTo = scene;
        In();
    }

    public void TriggerChangeScene()
    {
        if(sceneToChangeTo ==  currentScene) return;
        StartCoroutine(LoadSceneSequence(sceneToChangeTo));
    }

    public IEnumerator LoadSceneSequence(Enums.SubScenes scene)
    {

        AsyncOperation unloadScene = SceneManager.UnloadSceneAsync(currentScene.ToString());
        while (!unloadScene.isDone)
        {
            yield return null;
        }
        currentScene = scene;
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(currentScene.ToString(), LoadSceneMode.Additive);
        while (!loadScene.isDone)
        {
            yield return null;
        }
        Out();
    }

    public Enums.SubScenes GetCurrentScene()
    {
        return currentScene;
    }
}
