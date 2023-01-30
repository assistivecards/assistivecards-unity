using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject balloonPrefab;
    public Color[] colors;
    private void OnEnable()
    {
        for (int i = 0; i < 5; i++)
        {
            var randomValue = Random.Range(-8, 8);
            var balloon = Instantiate(balloonPrefab, new Vector3(randomValue, -7, 0), Quaternion.identity);
            balloon.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
            LeanTween.move(balloon, new Vector3(randomValue, 7, 0), Random.Range(2, 5));
        }

        Invoke("DestroyBalloons", 5f);
    }

    public void DestroyBalloons()
    {
        var balloons = GameObject.FindGameObjectsWithTag("Balloon");
        foreach (var balloon in balloons)
        {
            Destroy(balloon);
        }
    }
}
