using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private GameObject levelChangeScreen;
    [SerializeField] private PackageSelectManager packageSelectManager;
    private BoardGenerator boardGenerator;
    private bool levelFinished = false;

    private void Awake() 
    {
        boardGenerator = this.GetComponent<BoardGenerator>();    
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }
    public async void levelFinisher()
    {
        if(GameObject.FindGameObjectsWithTag("notMatchedCard").Length == 0)
        {
            LeanTween.scale(this.gameObject, Vector3.one * 0.0001f, 0.01f);
            gameAPI.PlaySFX("Finished");
            boardGenerator.ClearBoard();
            levelChangeScreen.SetActive(true);

            LeanTween.scale(this.gameObject, Vector3.one * 0.0001f, 0.1f);
        }
    }
}
