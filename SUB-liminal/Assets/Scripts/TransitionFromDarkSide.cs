using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionFromDarkSide : MonoBehaviour
{

    [SerializeField]
    private string sceneName;

    [SerializeField]
    private GameObject finalCatInteraction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (finalCatInteraction == null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

   
}
