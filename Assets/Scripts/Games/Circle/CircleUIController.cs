using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleUIController : MonoBehaviour
{
    [SerializeField] BoardGeneration board;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject packSelectionPanel;
    [SerializeField] GameObject helloText;
    [SerializeField] GameObject speakerIcon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBackButtonClick()
    {
        StartCoroutine(BackButtonClickCoroutine());
    }

    IEnumerator BackButtonClickCoroutine()
    {
        if (GameObject.Find("Card1").transform.localScale == Vector3.one && GameObject.Find("Card1").GetComponent<Image>().sprite != null)
        {
            // ResetCounter();
            board.ScaleImagesDown();
            // LeanTween.scale(backButton, Vector3.zero, 0.25f);
            backButton.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            board.ClearBoard();
            packSelectionPanel.transform.localScale = new Vector3(0, 0, 0);
            var rt = packSelectionPanel.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
            rt.offsetMax = new Vector2(rt.offsetMax.x, 0);
            packSelectionPanel.SetActive(true);
            LeanTween.scale(packSelectionPanel, Vector3.one, 0.25f);
            Invoke("EnableScrollRect", 0.26f);
            helloText.SetActive(true);
            speakerIcon.SetActive(true);
        }

    }

    public void EnableScrollRect()
    {
        packSelectionPanel.transform.GetChild(0).GetComponent<ScrollRect>().enabled = true;
    }
}
