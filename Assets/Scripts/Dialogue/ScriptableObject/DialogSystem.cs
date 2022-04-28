using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem instance;
    //Static instance of the Dialogue Manager
    public Conversation conversation;
    //Whats the conversation that is going to be displayed
    public Conversation defaultConversation;
    //The default Conversation when the first conversation is over


    #region These GameObjects are only used to set the SpeakerUI. Are they necessary? Could just set SpeakerUI in inspector if that's what you're doing with GameObjects
    public GameObject  speakerOne;
    //Who is the first Speaker?
    public GameObject  speakerTwo;
    //Who is the second Speaker?
    #endregion
    private SpeakerUI  speakerUIOne;
    //Reference of the Script that controls the UI of the first Speaker
    private SpeakerUI  speakerUITwo;
    //Reference of the Script that controls the UI of the second  Speaker
    private SpeakerUI  currentSpeaker;

    public NPCInteraction NPCDisponible { get; set; }
    public GameObject iconNext;
    //Reference to the Icon that shows the Player it can continue to next piece of dialogue
    
    private int activeLineIndex = 0;
    //Active line where we're at
  
    private bool conversationStarted = false;
    private bool isWritingLine = false;
  
    private void ChangeConversation(Conversation nextConversation)
    {
      conversationStarted = false;
      conversation = nextConversation;
      AdvanceLine();
    }

    private void Awake()
    {
        if (instance !=null)
        {
            Destroy(gameObject);
            Debug.LogWarning("Found more than one instances of Dialogue Manager System on the scene. Destroying one of them.");
            //Throw a warning if two or more instances have been found in the scene
        }
        else //Initialize the instance
            instance = this;
    }

    public void  Start()
    {
       iconNext.SetActive(false);
       //Hide the icon that is shown for the Player to indicate that the Dialogue can continue

      speakerUIOne = speakerOne.GetComponent<SpeakerUI>();
      speakerUITwo = speakerTwo.GetComponent<SpeakerUI>();
      //Speaker set based on the conversation
    }

    private void Update()
    {
         if(Input.GetKeyDown(KeyCode.Z))
            AdvanceLine();
    }

    private void EndConversation()
    {
      conversation = defaultConversation;
      conversationStarted = false;
      speakerUIOne.Hide();
      speakerUITwo.Hide();
    }

    private void Initialize()
    {
      conversationStarted = true;
      activeLineIndex = 0;
      speakerUIOne.Speaker  = conversation.speaker1;
      speakerUITwo.Speaker = conversation.speaker2;
      currentSpeaker = speakerUIOne;
    }

    private void AdvanceLine()
    {
        if(conversation == null)
            return;
        
        if(!conversationStarted)
          Initialize();

        if(isWritingLine)
        {
            isWritingLine = false;
            //Stop the coroutine from writing any more letters
            StopAllCoroutines();
            //Display the full line
            currentSpeaker.Dialog = conversation.lines[activeLineIndex].text;
        }
        else if(activeLineIndex < conversation.lines.Length)
          DisplayLine();
        else
          AdvanceConversation();
    }

    private void DisplayLine()
    {
        SetDialog(conversation.lines[activeLineIndex]);
        activeLineIndex++;
    }

    private void AdvanceConversation()
    {
        if (conversation.nextConversation != null)
            ChangeConversation(conversation.nextConversation);
        else
            EndConversation();
        

    }

    private void SetDialog(Line line)
    {
        SwitchSpeaker();
        
        currentSpeaker.Dialog = string.Empty;
        
        iconNext.SetActive(false);
        currentSpeaker.Mood = line.mood;
        
        StopAllCoroutines();
        StartCoroutine(EffectTypewriter(line.text));
    }

    void SwitchSpeaker()
    {
        currentSpeaker.Hide();
        currentSpeaker = (currentSpeaker == speakerUIOne) ? speakerUITwo : speakerUIOne;
        currentSpeaker.Show();
    }

    private IEnumerator EffectTypewriter(string text)
    {
        isWritingLine = true; 
        iconNext.SetActive(true);

        foreach(char character in text.ToCharArray())
        {
            currentSpeaker.Dialog += character;
            yield return new  WaitForSeconds(0.05f);
        }
        
        isWritingLine = false;
    }
}