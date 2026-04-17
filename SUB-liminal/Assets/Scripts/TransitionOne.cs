using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionOne : MonoBehaviour
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
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Orb"))
        {
            if(finalCatInteraction == null)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
