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

        if(match)
        {
            Invoke("TTSCardName" , 0.1f);
            match = false;
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
        gameAPI.Speak(matchedList.Last());
        Invoke("ResetLists", 2);
    }

}
