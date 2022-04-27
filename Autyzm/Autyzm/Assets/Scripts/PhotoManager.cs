using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class PhotoManager : MonoBehaviour
{
    public static PhotoManager instance;

    [SerializeField] private List<Photo> AllPhotosList = new List<Photo>();
    
    private List<Photo> photosListOneCharacter = new List<Photo>();
    private List<Photo> photosListTwoCharacters = new List<Photo>();
    private List<Photo> photosListThreeCharacters = new List<Photo>();

    private List<Photo> photosWithDog = new List<Photo>();

    private Photo currentPhoto;
    
    [SerializeField] private SpriteRenderer photoDisplay;

    [Range(0,1)]
    [SerializeField] private float dogProbability;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        FillLists();
        
        LoadPhoto();
    }

    public void LoadPhoto()
    {
        
        if ((new Random().NextDouble() < dogProbability || CharactersListsAreEmpty()) &&
            photosWithDog.Count > 0)
        {
            ChangePhoto(photosWithDog);
            return;
        }

        if (photosListOneCharacter.Count > 0)
        {
            ChangePhoto(photosListOneCharacter);
            return;
        }
        
        if (photosListTwoCharacters.Count > 0)
        {
            ChangePhoto(photosListTwoCharacters);
            return;
        }
        
        if (photosListThreeCharacters.Count > 0)
        {
            ChangePhoto(photosListThreeCharacters);
            return;
        }
        
        GameManager.instance.TurnOnPlayAgainPanel();
    }

    private void ChangePhoto(List<Photo> photoList)
    {
        int index = new Random().Next(photoList.Count);
        photoDisplay.sprite = photoList[index].photo;
        currentPhoto = photoList[index];
        photoList.RemoveAt(index);

    }

    private bool CharactersListsAreEmpty()
    {
        if (photosListOneCharacter.Count == 0 &&
            photosListTwoCharacters.Count == 0 &&
            photosListThreeCharacters.Count == 0)
        {
            return true;
        }

        return false;
    }

    public bool AllListsAreEmpty()
    {
        if (CharactersListsAreEmpty() && photosWithDog.Count == 0)
        {
            return true;
        }

        return false;
    }

    public void CheckAnswer(CharacterMood mood)
    {
        if (mood == currentPhoto.characterMood)
        {
            GameManager.instance.AddScore();
            LoadPhoto();
        }
        else
        {
            LoadPhoto();
        }
    }

    public void CheckAnswer(int mood)
    {
        if (mood == Convert.ToInt32(currentPhoto.characterMood))
        {
            GameManager.instance.AddScore();
            LoadPhoto();
        }
        else
        {
            LoadPhoto();
        }
    }

    public void FillLists()
    {
        photosWithDog = AllPhotosList.FindAll(photo => photo.isCharacterDog);
        
        photosListOneCharacter = AllPhotosList.FindAll(photo => photo.characterAmount == 1 && !photo.isCharacterDog);
        photosListTwoCharacters = AllPhotosList.FindAll(photo => photo.characterAmount == 2 && !photo.isCharacterDog);
        photosListThreeCharacters = AllPhotosList.FindAll(photo => photo.characterAmount > 2 && !photo.isCharacterDog);
    }
}
