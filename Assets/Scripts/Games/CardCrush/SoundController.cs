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

    public List<string> movedTargetList = new List<string>();
    public List<string> movedList = new List<string>();
    public List<string> matchedList = new List<string>();

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Update() 
    {
      ReadCard();
    }

    private void ReadCard()
    {
        if(matchedList.Count > 0 && movedList.Count > 0)
        {
            if(matchedList.Last() == movedList.Last())
            {
                gameAPI.Speak(matchedList.Last());
                matchedList.Clear();
                movedList.Clear();
                movedTargetList.Clear();
            }
        }
        if(matchedList.Count > 0 && movedTargetList.Count > 0)
        {
            if(matchedList.Last() == movedTargetList.Last())
            {
                gameAPI.Speak(matchedList.Last());
                matchedList.Clear();
                movedList.Clear();
                movedTargetList.Clear();
            }
        }
    }

    public void TTSCardName()
    {
        gameAPI.Speak(matchedList.Last());
        matchedList.Clear();
        movedList.Clear();
        movedTargetList.Clear();
    }

}
