using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum InteraccionExtraNPC
{
    Quests,
    Shop,
    Crafting
}

 /*There would be an enum so the NPCS have the availability of including Quests
   or Exchanges(Buy/Sell) with the Player or Crafting stuff for the Player*/


public enum Mood
 {
    Neutral,
    Angry,
    Happy,
    Sad,
    Thoughtful
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
 [Header("Info")]

    public Character speaker1;
    //Mugshot/Portrait of the first character on the conversation
    public Character speaker2;
    //Mugshot/Portrait of the second character on the conversation

    [Header("Chat")]
    public Line[] lines;
    //The lines of Dialogue
    //Dialogue Array

    [Header("Extra Interaction")]
    public Conversation nextConversation;
    /*All of before is going to be seen on the Unity UI, in the Inspector*/
    public bool ContieneInteraccionExtra;
    //Is there an extra interaction?
    public InteraccionExtraNPC InteraccionExtra;
    //If there is an extra interaction, what type of interaction is going to be

}


[Serializable] 
public class Line
{
    public Character character;

    [TextArea(2, 5)]
    public string text;
    public Mood mood;
    //Dropdown for  each line, select a mood of the character
    
    /*Each line has a character  and a text*/
}
/* Each line has one of the character and text, which also includes 
   a mood of the character during said line of dialogue.
Serializable means something is editable within the Editor*/
