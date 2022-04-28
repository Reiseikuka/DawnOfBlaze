using UnityEngine;
using UnityEngine.UI;


public class SpeakerUI : MonoBehaviour
{
    //SpeakerUI Script will reference Key items: Portrait, Name, Dialog
    public Image portrait;
    //Reference of the mugshot of the character
    public Text characterName;
    //Reference of the name of the character
    public Text dialog;
    public Mood mood;
    /*Reference of the mood the character is on through the convo
     It allow us to choose different moods as long as they are set in the Conversation*/

    private Character speaker;


    public Character Speaker
    {
        get { return speaker; }
        set
        {
            speaker = value;
            //Who is the actual speaker
            characterName.text =  speaker.fullName;
            //Brings the Speaker name
        }
        //Tracks the Speaker with their info
    }

    public string Dialog
    {
        get { return dialog.text; }
        set { dialog.text = value; }
    }
    //Setting the Dialogue text based on whats assigned


    public Mood Mood
    {
        set 
        {
            Sprite sprite;
            if (value == Mood.Angry) {
                sprite = speaker.portraitAngry;
            } else if (value == Mood.Happy)
            {
                sprite = speaker.portraitHappy;
            } else if (value == Mood.Sad)
            {
                sprite = speaker.portraitSad;
            } else if (value == Mood.Thoughtful)
            {
                sprite = speaker.portraitThoughtful;
            }
            else {
                sprite = speaker.portraitNeutral;
            }

            /*Get the sprite if  the value being passed into Mood 
                hereis equal  to   a correspondant mood.
                Example: If mood is Angry, set the mugshot correspondant
                to the Angry mood of the correspondant character*/

            portrait.sprite = sprite;
            //For the portrait, set the sprite that was selected above
        }

    }

    public bool HasSpeaker()
    {
        return speaker != null;
    }
    //Corroborate if this UI has a speaker already

    public bool SpeakerIs(Character character)
    {
        return speaker == character;
    }
    //Corroborate if its the speaker in question

    public void Show()
    {
        gameObject.SetActive(true);
    }
    //Showing the UI

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    //Hiding the UI
}
