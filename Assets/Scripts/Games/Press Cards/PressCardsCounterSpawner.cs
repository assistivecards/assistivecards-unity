using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class PressCardsCounterSpawner : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] List<Transform> availableSpawnPoints = new List<Transform>();
    [SerializeField] GameObject counter;

    public void OnPointerClick(PointerEventData eventData)
    {
        SpawnCounter();
    }

    public void SpawnCounter()
    {
        availableSpawnPoints = spawnPoints.Where(spawnPoint => spawnPoint.childCount == 0).ToList();
        var randomIndex = Random.Range(0, availableSpawnPoints.Count);

        var counterObject = Instantiate(counter, availableSpawnPoints[randomIndex].position, Quaternion.identity);
        counterObject.transform.SetParent(availableSpawnPoints[randomIndex]);
        counterObject.transform.rotation = counterObject.transform.parent.rotation;
        counterObject.transform.localScale = Vector3.one;
        Destroy(counterObject, .25f);

    }
}
