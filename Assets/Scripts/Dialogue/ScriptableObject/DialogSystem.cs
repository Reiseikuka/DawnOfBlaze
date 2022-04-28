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
    Conversation originalConversation;
    public SpeakerUI  speakerUIOne;
    //Reference of the Script that controls the UI of the first Speaker
    public SpeakerUI  speakerUITwo;
    //Reference of the Script that controls the UI of the second  Speaker
    private SpeakerUI  currentSpeaker;

    public NPCInteraction NPCDisponible { get; set; }
    public GameObject iconNext;
    //Reference to the Icon that shows the Player it can continue to next piece of dialogue
    
    private int activeLineIndex = 0;
    //Active line where we're at

    public NPCInteraction myInteractionRange;
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

        myInteractionRange = GetComponentInParent<NPCInteraction>();
        originalConversation = conversation;
    }

    private void OnEnable() {
        myInteractionRange.onInteract += AdvanceLine;
        myInteractionRange.onPlayerLeave += WalkedAwayFromConversation;
    }
    private void OnDisable() {
        myInteractionRange.onInteract -= AdvanceLine;
        myInteractionRange.onPlayerLeave -= WalkedAwayFromConversation;
    }
    public void  Start()
    {
       iconNext.SetActive(false);
       //Hide the icon that is shown for the Player to indicate that the Dialogue can continue
    }

    void WalkedAwayFromConversation()
    {
        if(conversation == defaultConversation) return;

        EndConversation();

        StopAllCoroutines();
        isWritingLine = false;
        
    }

    private void EndConversation()
    {
        conversation = defaultConversation;
        conversationStarted = false;
        speakerUIOne.Hide();
        speakerUITwo.Hide();
        iconNext.SetActive(false);
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
        {
            DisplayLine();
            activeLineIndex++;
        }
        else
          AdvanceConversation();
    }

    private void DisplayLine()
    {
        SetDialog(conversation.lines[activeLineIndex]);
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
        

        foreach(char character in text.ToCharArray())
        {
            currentSpeaker.Dialog += character;
            yield return new  WaitForSeconds(0.05f);
        }
        iconNext.SetActive(true);
        isWritingLine = false;
    }

    public void ResetDialog()
    {
        conversation = originalConversation;
    }
}