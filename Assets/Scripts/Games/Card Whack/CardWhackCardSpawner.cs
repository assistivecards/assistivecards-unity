using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

public class CardWhackCardSpawner : MonoBehaviour
{
    [SerializeField] Transform[] slots;
    [SerializeField] List<Transform> availableSlots = new List<Transform>();
    [SerializeField] GameObject cardPrefab;
    private CardWhackBoardGenerator board;

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<CardWhackBoardGenerator>();
    }

    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     SpawnCard();
    // }

    public void SpawnCard()
    {
        availableSlots = slots.Where(spawnPoint => spawnPoint.childCount == 0).ToList();

        var randomIndex = Random.Range(0, availableSlots.Count);

        var cardObject = Instantiate(cardPrefab, availableSlots[randomIndex].position, Quaternion.identity);
        cardObject.transform.SetParent(availableSlots[randomIndex]);
        cardObject.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-20, 20));
        cardObject.transform.GetChild(0).GetComponent<Image>().sprite = board.randomSprites[Random.Range(0, board.randomSprites.Count)];
        LeanTween.scale(cardObject, Vector3.one, .25f);
        StartCoroutine(FadeCard(cardObject));

    }

    public IEnumerator FadeCard(GameObject card)
    {
        yield return new WaitForSeconds(1f);
        LeanTween.alpha(card.GetComponent<RectTransform>(), 0, .25f).setDestroyOnComplete(true);
    }
}
