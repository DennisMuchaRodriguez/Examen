using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK : MonoBehaviour
{
    public GameObject[] characters;
    private int currentCharacterIndex = 0;
    private int previousCharacterIndex = 0;

    void Start()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (i != currentCharacterIndex)
            {
                characters[i].SetActive(false);
            }
        }
    }


    public void SwitchToPreviousCharacter()
    {
        characters[previousCharacterIndex].SetActive(false); 
        currentCharacterIndex = (currentCharacterIndex - 1 + characters.Length) % characters.Length;
        characters[currentCharacterIndex].SetActive(true); 
        previousCharacterIndex = currentCharacterIndex; 
    }

    public void SwitchToNextCharacter()
    {
        characters[previousCharacterIndex].SetActive(false); 
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;
        characters[currentCharacterIndex].SetActive(true);
        previousCharacterIndex = currentCharacterIndex; 
    }
}
