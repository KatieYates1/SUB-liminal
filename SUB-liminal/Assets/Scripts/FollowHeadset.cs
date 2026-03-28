using UnityEngine;

public class FollowHeadset : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    public Transform headsetTransform;

    public float distanceFromHeadset = 2.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (headsetTransform != null)
        {
            // Position the UI in front of the headset
            transform.position = headsetTransform.position + headsetTransform.forward * distanceFromHeadset;
            
            transform.rotation = headsetTransform.rotation;
        }
    }
}
