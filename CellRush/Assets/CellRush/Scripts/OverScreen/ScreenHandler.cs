using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
using Unity.VisualScripting;

public class ScreenHandler : MonoBehaviour
{
    public static ScreenHandler Instance { get; private set; }

    [SerializeField] private ScreenLoader screenLoader;
    [SerializeField] private Enums.SubScenes debug_screenToChangeTo;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
    }

    public static void ChangeScreen_Static(Enums.SubScenes newScreen)
    {
        Instance.ChangeScreen(newScreen);
    }
    public void ChangeScreen(Enums.SubScenes newScreen)
    {
        screenLoader.ChangeScene(newScreen);

    }
    public Enums.SubScenes GetCurrentScreen()
    {
        return screenLoader.GetCurrentScene();
    }
    [Button("Test Screen Change")]
    private void TestScreenChange()
    {
        ChangeScreen(debug_screenToChangeTo);
    }
}
