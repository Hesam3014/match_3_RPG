using UnityEngine;

public class TestUi : MonoBehaviour
{
    public static TestUi instance;
    private void Awake()
    {
        makesingleton();
    }
    private void Start()
    {
       
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

            Destroy(GameObject.Find("GameManager(Clone)"));

           // GameObject.Find("Loading").GetComponent<LoadScene>().lodingTest();
        }
        // DontDestroyOnLoad(gameObject);
    }
}
