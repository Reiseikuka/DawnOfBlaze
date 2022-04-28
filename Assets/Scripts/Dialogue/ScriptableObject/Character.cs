using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]

//Allow us to create a Character with Unity Editor UI along its different portraits
public class Character : ScriptableObject
{
    public string fullName;
    //Full name of the character
    public Sprite portraitNeutral;
    //Mugshot/Portrait of the character on a Neutral state
    public Sprite portraitAngry;
    //Mugshot/Portrait of the character on an Angry state

    public Sprite portraitHappy;
    //Mugshot/Portrait of the character on a Happy emotion
    public Sprite portraitSad;
    //Mugshot/Portrait of the character going through a sad moment
    public Sprite portraitThoughtful;
    //Mugshot/Portrait of the character on a Thoughtful manner

    /*All of before is going to be seen on the Unity UI, in the Inspector*/

}
