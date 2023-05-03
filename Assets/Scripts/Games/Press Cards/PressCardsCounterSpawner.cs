using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

public class PressCardsCounterSpawner : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Transform[] spawnPointsLeft;
    [SerializeField] Transform[] spawnPointsRight;
    [SerializeField] List<Transform> availableSpawnPointsLeft = new List<Transform>();
    [SerializeField] List<Transform> availableSpawnPointsRight = new List<Transform>();
    [SerializeField] Sprite[] countingNumbersImages;
    [SerializeField] GameObject counterPrefab;
    public int counter;
    PressCardsBoardGenerator board;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<PressCardsBoardGenerator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SpawnCounter();
    }

    public void SpawnCounter()
    {
        if (counter < board.pressCount)
        {
            gameAPI.PlaySFX("Count");

            availableSpawnPointsLeft = spawnPointsLeft.Where(spawnPoint => spawnPoint.childCount == 0).ToList();
            availableSpawnPointsRight = spawnPointsRight.Where(spawnPoint => spawnPoint.childCount == 0).ToList();

            if (counter % 2 == 0)
            {
                var randomIndex = Random.Range(0, availableSpawnPointsRight.Count);

                var counterObject = Instantiate(counterPrefab, availableSpawnPointsRight[randomIndex].position, Quaternion.identity);
                counterObject.transform.SetParent(availableSpawnPointsRight[randomIndex]);
                counterObject.transform.rotation = counterObject.transform.parent.rotation;
                // counterObject.transform.localScale = Vector3.one;
                counterObject.transform.GetChild(0).GetComponent<Image>().sprite = countingNumbersImages[counter];
                LeanTween.scale(counterObject, Vector3.one, .25f);
                StartCoroutine(FadeCounter(counterObject));

                counter++;
                // Destroy(counterObject, .5f);
            }

            else if (counter % 2 == 1)
            {
                var randomIndex = Random.Range(0, availableSpawnPointsLeft.Count);

                var counterObject = Instantiate(counterPrefab, availableSpawnPointsLeft[randomIndex].position, Quaternion.identity);
                counterObject.transform.SetParent(availableSpawnPointsLeft[randomIndex]);
                counterObject.transform.rotation = counterObject.transform.parent.rotation;
                // counterObject.transform.localScale = Vector3.one;
                counterObject.transform.GetChild(0).GetComponent<Image>().sprite = countingNumbersImages[counter];
                LeanTween.scale(counterObject, Vector3.one, .25f);
                StartCoroutine(FadeCounter(counterObject));

                counter++;
                // Destroy(counterObject, .5f);
            }


        }

    }

    public IEnumerator FadeCounter(GameObject counter)
    {
        yield return new WaitForSeconds(.25f);
        LeanTween.alpha(counter.GetComponent<RectTransform>(), 0, .25f).setDestroyOnComplete(true);
    }
}
