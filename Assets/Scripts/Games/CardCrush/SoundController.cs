using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoundController : MonoBehaviour
{
    GameAPI gameAPI;
    public string moved;
    public string matched;
    public bool isMovedGlobal = false;

    public bool match = false;
    public List<string> movedTargetList = new List<string>();
    public List<string> movedList = new List<string>();
    public List<string> matchedList = new List<string>();

    bool successOneTime = true;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }
    
    private void Start() 
    {
        gameAPI.PlayMusic();
    }

    private void Update() 
    {
      ReadCard();
    }

    public void ReadMatch()
    {
        if(match)
        {
            Invoke("TTSCardName" , 0.1f);
            match = false; 
        }
    }

    public void ReadCardBlast()
    {
        if(matchedList.Count > 0)
        {
            gameAPI.PlaySFX("Success");
            gameAPI.Speak(matchedList.Last());
            Debug.Log(matchedList.Last());
        }
    }

    private void ReadCard()
    {
        if(matchedList.Count > 0 && movedList.Count > 0)
        {
            if(matchedList.Last() == movedList.Last())
            {
                gameAPI.PlaySFX("Success");
                gameAPI.Speak(matchedList.Last());
            }
        }
        if(matchedList.Count > 0 && movedTargetList.Count > 0)
        {
            if(matchedList.Last() == movedTargetList.Last())
            {
                gameAPI.PlaySFX("Success");
                gameAPI.Speak(matchedList.Last());
            }
        }
    }

    private void ResetLists()
    {
        matchedList.Clear();
        movedList.Clear();
        movedTargetList.Clear();
    }

    public void TTSCardName()
    {
        Debug.Log(matchedList.Last());
        gameAPI.Speak(matchedList.Last());
        Invoke("ResetLists", 0.5f);
    }

    public void TriggerSuccessSFX()
    {
        if(successOneTime)
        {
            gameAPI.PlaySFX("Success");
            Debug.Log("Successs");
            successOneTime = false;
        }
        Invoke("SuccessBoolTrue", 1f);
    }

    private void SuccessBoolTrue()
    {
        successOneTime = true;
    }
}
