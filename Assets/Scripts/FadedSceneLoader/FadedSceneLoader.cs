using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadedSceneLoader : MonoBehaviour
{
    private static bool loadingHandlerAttached = false;
    private static FadedSceneLoader _instance;
    private static FadedSceneLoader Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject loaderObject = new GameObject();
                loaderObject.name = "FadedSceneLoader_Instance";
                _instance = loaderObject.AddComponent<FadedSceneLoader>();
                _instance.Initialize();
            }
            return _instance;
        }
    }
    private bool _isInit = false;

    private Image faderImage;
    private GameObject faderCanvasObject;
    private static SceneLoadParameters parameters = new SceneLoadParameters();
    private static bool fadeInAfterLoad = false;

    // first time active, awake is used to subscribe to scene load event
    void Awake()
    {
        if (!loadingHandlerAttached)
        {
            loadingHandlerAttached = true;
            SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }
    }

    static void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Instance.Initialize();
        if (fadeInAfterLoad)
        {
            Instance.StartCoroutine(Instance.SceneFadeIn());
        }
    }

    private void Initialize()
    {
        if (!_isInit)
        {
            faderCanvasObject = new GameObject();
            faderCanvasObject.name = "FaderCanvas_Instance";
            faderCanvasObject.transform.SetParent(transform);
            Canvas canvas = faderCanvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 1000;

            GameObject imageObject = new GameObject();
            imageObject.name = "FaderImage_Instance";
            imageObject.transform.SetParent(faderCanvasObject.transform);
            faderImage = imageObject.AddComponent<Image>();
            faderImage.rectTransform.anchorMax = new Vector2(1, 1);
            faderImage.rectTransform.anchorMin = new Vector2(0, 0);
            faderImage.rectTransform.offsetMax = new Vector2(0, 0);
            faderImage.rectTransform.offsetMin = new Vector2(0, 0);
            faderImage.color = new Color(0, 0, 0, 0);
        }
        _isInit = true;
    }

    public static void LoadScene(string newScene, float fadeOutTime = 1, float fadeInTime = 1, bool fadeInAfterLoad = true, bool waitForOkGo = false)
    {
        LoadScene(newScene, Color.black, fadeOutTime, fadeInTime, fadeInAfterLoad, waitForOkGo);
    }

    public static void LoadScene(string newScene, Color fadeColor, float fadeOutTime = 1, float fadeInTime = 1, bool fadeInAfterLoad = true, bool waitForOkGo = false)
    {
        parameters.fadeOutTime = fadeOutTime;
        parameters.fadeInTime = fadeInTime;
        parameters.fadeColor = fadeColor;
        parameters.newScene = newScene;
        parameters.isActive = true;
        parameters.isOkToGo = false;
        parameters.waitForOK = waitForOkGo;
        FadedSceneLoader.fadeInAfterLoad = fadeInAfterLoad;
        Instance.StartCoroutine(Instance.SceneLoaderRoutine());
    }

    public static void SetOkGo()
    {
        if (!parameters.isActive)
        {
            Debug.LogError("FadedSceneLoader cant set OkGo, no scene to load in queue");
            return;
        }
        if (!parameters.waitForOK)
        {
            Debug.LogError("FadedSceneLoader does not wait for an OkGo");
            return;
        }
        parameters.isOkToGo = true;
    }

    private IEnumerator SceneLoaderRoutine()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(parameters.newScene);
        operation.allowSceneActivation = false;
        while(parameters.waitForOK && !parameters.isOkToGo)
        {
            yield return null;
        }
        yield return StartCoroutine(SceneFadeOut());
        operation.allowSceneActivation = true;
    }

    private IEnumerator SceneFadeOut()
    {
        faderCanvasObject.SetActive(true);
        Color targetColor = parameters.fadeColor;
        float startTime = Time.time;
        while (startTime + parameters.fadeOutTime > Time.time)
        {
            float normalizedTime = (Time.time - startTime) / parameters.fadeOutTime;
            targetColor.a = normalizedTime;
            faderImage.color = targetColor;
            yield return new WaitForEndOfFrame();
        }
        targetColor = parameters.fadeColor;
        targetColor.a = 1;
        faderImage.color = targetColor;
        yield return new WaitForEndOfFrame();
    }

    private IEnumerator SceneFadeIn()
    {
        faderCanvasObject.SetActive(true);
        fadeInAfterLoad = false;
        parameters.isActive = false;
        parameters.waitForOK = false;
        parameters.isOkToGo = false;
        float fateTime = parameters.fadeInTime;
        Color fadeColor = parameters.fadeColor;
        float fadeOutTime = parameters.fadeOutTime;
        float startTime = Time.time;
        while (startTime + fateTime > Time.time)
        {
            float normalizedTime = (Time.time - startTime) / fadeOutTime;
            Color targetColor = fadeColor;
            targetColor.a = 1 - normalizedTime;
            faderImage.color = targetColor;
            yield return null;
        }
        faderCanvasObject.SetActive(false);
    }

    internal class SceneLoadParameters
    {
        internal float fadeOutTime;
        internal float fadeInTime;
        internal Color fadeColor;
        internal string newScene;
        internal bool waitForOK;
        internal bool isOkToGo;
        internal bool isActive;

        public SceneLoadParameters()
        {
            fadeOutTime = 0;
            fadeInTime = 0;
            fadeColor = Color.black;
            waitForOK = false;
            isOkToGo = false;
            isActive = false;
        }
    }
}
