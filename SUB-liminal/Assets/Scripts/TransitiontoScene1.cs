using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitiontoScene1 : MonoBehaviour
{
    [SerializeField]
    private GameObject script;
    [SerializeField]
    private string sceneName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(script == null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
