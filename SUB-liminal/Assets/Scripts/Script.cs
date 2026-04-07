using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.UI;

public class Script : MonoBehaviour
{
    // The compiled JSON asset 
    public TextAsset inkAsset;
    // The Ink story we are wrapping 
    Story _inkStory;

    [SerializeField]
    public Canvas dialogueCanvas;
    [SerializeField]
    public float elementPadding; 
    [SerializeField]
    public GameObject textUI;
    [SerializeField]
    public Button button;
    [SerializeField]
    public Transform choiceSection;
    [SerializeField]
    public GameObject continueButton;

    private bool showingChoices = false; 

    private void Awake()
    {
        _inkStory = new Story(inkAsset.text);
    }

    private void Start()
    {
        // Show the text 
        textUI.SetActive(true);
    }

    private void Update()
    {
        // If there are choices that need to be shown 
        if (_inkStory.currentChoices.Count > 0)
        {
            ShowChoices();
        }
    }

    public void Continue()
    {
        if (_inkStory.canContinue)
        {
            float offset = 0;
            // Set get the UI object
            TextMeshProUGUI textMeshProUGUI = textUI.GetComponent<TextMeshProUGUI>();
            // Change the text to be the next text 
            textMeshProUGUI.text = _inkStory.Continue();
            // Set the parent to the dialogueCanvas 
            textMeshProUGUI.transform.SetParent(dialogueCanvas.transform, false);
            textMeshProUGUI.transform.Translate(new Vector2(0, offset));
            offset -= (textMeshProUGUI.fontSize + elementPadding);
        }
        else
        {
            Debug.Log("Can't continue");
        }
    }

    public void ShowChoices()
    {
        // Only runs if not already showing the choices
        if (!showingChoices)
        {
            // Get rid of the continue button 
            continueButton.SetActive(false);

            float offset = 0;        
            // Make choice 
            if (_inkStory.currentChoices.Count > 0)
            {
                // loop through choices
                for (int i = 0; i < _inkStory.currentChoices.Count; i++)
                {
                    // Create a new button from the prefab 
                    Button choiceButton = Instantiate(button);
                    // Set its position 
                    choiceButton.transform.SetParent(choiceSection, false);
                    choiceButton.transform.Translate(new Vector2(0, offset));

                    // Get the text component 
                    TextMeshProUGUI choiceText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
                    // Set the text shown on the button
                    choiceText.text = _inkStory.currentChoices[i].text;
                    // Change the button name to the index
                    choiceButton.name = i.ToString();

                    // Add the event listening -- when the button is created, make it so 
                    // that if it is clicked, it will go to ChoiceSelected and send itself 
                    choiceButton.onClick.AddListener(() => ChoiceSelected(choiceButton));

                }
            }
        }

        // We are now showing the choices 
        showingChoices = true;
    }

    public void RemoveChoices()
    {
        for (int i = 0; i < choiceSection.childCount; i++)
        {
            GameObject.Destroy(choiceSection.GetChild(i).gameObject);
        }
    }


    public void ChoiceSelected(Button button)
    {
        int id = int.Parse(button.name);
        _inkStory.ChooseChoiceIndex(id);

        // Now show the continute button 
        continueButton.SetActive(true);

        // Remove the button children 
        RemoveChoices();
        // After the next thing has been set up, automatically show the next dialogue 
        // I don't know why I have to call this twice ??
        Continue();
        Continue();
    }
}
  
