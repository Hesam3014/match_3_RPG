using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour
{
    public static LoadScene instance;
    public GameObject LoadingScreen;
    [SerializeField] private Image loadingImg;
    public bool loadedScene;
    public AsyncOperation operation;
    [SerializeField] float value;
    [SerializeField] int Level;
    private void Awake()
    {
        makesingleton();
    }
    private void Start()
    {
        Level = PlayerPrefs.GetInt("Level", 0);
        LoadingScene();
    }
    void makesingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // DontDestroyOnLoad(gameObject);
    }

    public void LoadingScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Additive);
        if (!loadedScene)
        {
            StartCoroutine(LoadingScene(Level));
            // Destroy(LoadingScreen, 8f);
        }



    }

    public void lodingTest()
    {
        Level = PlayerPrefs.GetInt("Level", 0);
        StartCoroutine(LoadingScene(Level));
    }
    private void Update()
    {
        loadingImg.fillAmount = Mathf.Lerp(loadingImg.fillAmount, value, 0.1f);
        if (loadingImg.fillAmount == 1f)
        {
            if (operation.isDone)
            {
                Invoke("Done", 0.5f);

            }
        }

       
    }
    void Done()
    {
        LoadingScreen.SetActive(false);
        loadedScene = true;
        //  Destroy(this.gameObject, 0.3f);
        PlayerPrefs.SetInt("DoMoveCamera", 1);
        StopCoroutine(LoadingScene(0));
    }
    IEnumerator LoadingScene(int IndexScene)
    {
        operation = SceneManager.LoadSceneAsync(IndexScene);
        LoadingScreen.SetActive(true);
        while (loadingImg.fillAmount <= 1f)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.6f));
            // UpdateLoading(value);
            value += Random.Range(0.01f, 0.18f);
        }


    }


}
