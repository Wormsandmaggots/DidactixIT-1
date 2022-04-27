using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterMood
{
   Happy,
   Sad
}

[CreateAssetMenu(fileName = "New Photo", menuName = "Photo")]
public class Photo : ScriptableObject
{
   public Sprite photo;

   public CharacterMood characterMood;

   public bool isCharacterDog;

   public int characterAmount;
}
