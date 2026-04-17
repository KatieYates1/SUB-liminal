using UnityEngine;

public class CatTextManager : MonoBehaviour
{

    [SerializeField]
    private GameObject catText1;
    [SerializeField] 
    private GameObject catText2;
    [SerializeField] 
    private GameObject catText3;

    private float timer1 = 3f;
    private float timer2 = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        catText1.SetActive(false);
        catText2.SetActive(false);
        catText3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(catText1 != null)
        {
            catText1.SetActive(true);
        }
        else if(catText1 == null && catText2 != null)
        {
            if (timer1 > 0)
            {
                timer1 -= Time.deltaTime;
                if (timer1 <= 0)
                {
                    catText2.SetActive(true);
                }
            }
                
        }
        else if(catText2 == null && catText3 != null)
        {
            
            if (timer2 > 0)
            {
                timer2 -= Time.deltaTime;
                if (timer2 <= 0)
                {
                    catText3.SetActive(true);
                }
            }
           
        }
    }
}
