using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject balloonPrefab;
    public int fastestMoveTime = 5;
    public int slowestMoveTime = 10;
    public int balloonAmount = 8;
    public float destroyTime = 13f;
    public Color[] colors;
    private GameObject gameCanvas;
    private float canvasOffset;
    private void OnEnable()
    {
        gameCanvas = GameObject.Find("GameCanvas");
        if (gameCanvas.GetComponent<Canvas>().renderMode == RenderMode.ScreenSpaceCamera)
        {
            canvasOffset = 3;
        }
        else
            canvasOffset = 300;
        Vector3[] worldCorners = new Vector3[4];
        gameCanvas.GetComponent<RectTransform>().GetWorldCorners(worldCorners);

        for (int i = 0; i < balloonAmount; i++)
        {
            var randomValue = Random.Range(worldCorners[0].x, worldCorners[3].x);
            var balloon = Instantiate(balloonPrefab, new Vector3(randomValue, worldCorners[0].y - canvasOffset, 0), Quaternion.identity);
            balloon.transform.SetParent(gameCanvas.transform);
            balloon.transform.localScale = Vector3.one * 2.5f;
            balloon.GetComponent<Image>().color = colors[Random.Range(0, colors.Length)];
            LeanTween.move(balloon, new Vector3(randomValue, worldCorners[1].y + canvasOffset, 0), Random.Range(fastestMoveTime, slowestMoveTime));
        }

        Invoke("DestroyBalloons", destroyTime);
    }

    public void DestroyBalloons()
    {
        var balloons = GameObject.FindGameObjectsWithTag("Balloon");
        foreach (var balloon in balloons)
        {
            LeanTween.alpha(balloon.GetComponent<RectTransform>(), 0, .25f);
            Destroy(balloon, .25f);
        }
    }

    private void OnDisable()
    {
        DestroyBalloons();
    }

}
