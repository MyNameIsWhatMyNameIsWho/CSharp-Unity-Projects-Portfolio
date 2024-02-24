using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    // CLICKER
    public TextMeshProUGUI scoreText;
    public float currentScore;
    public float hitPower;
    public float scoreIncreasedPerSecond;
    public float x;
    public int y;

    // SHOP
    public int shop1prize;
    public TextMeshProUGUI shop1Text;
    public int shop2prize;
    public TextMeshProUGUI shop2Text;
    public int shop3prize;
    public TextMeshProUGUI shop3Text;

    // HANDS CARE

    // Start is called before the first frame update
    void Start()
    {
        // CLICKER
        currentScore = 0;
        hitPower = 1;
        scoreIncreasedPerSecond = 1;
        x = 0f;
        y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // CLICKER
        scoreText.text = "Cookies: " + currentScore.ToString("0");
        scoreIncreasedPerSecond = x * Time.deltaTime;
        currentScore += scoreIncreasedPerSecond;

        // SHOP
        shop1Text.text = "Cost: " + shop1prize.ToString();
        shop2Text.text = "Cost: " + shop2prize.ToString();
        shop3Text.text = "Cost: " + shop3prize.ToString();

        // AMOUNT
    }

    // HIT
    public void Hit()
    {
        currentScore += hitPower;
    }

    // SHOP
    public void Shop1()
    {
        if (currentScore >= shop1prize) {
            currentScore -= shop1prize;
            hitPower += 1;
            shop1prize += 30;
        }
    }

    public void Shop2()
    {
        if (currentScore >= shop2prize)
        {
            currentScore -= shop2prize;
            x += 1;
            y += 1;
            shop2prize += 200;
            DrawSquare(y);
        }
    }

    public void Shop3()
    {
        if (currentScore >= shop3prize) 
        { 
            currentScore -= shop3prize;
            x *= 2.1f;
            shop3prize += 400;
        }
    }

    // HANDS DRAWING
    void DrawSquare(float y)
    {
        // Create a new GameObject for the GUI Image
        GameObject guiImageObject = new GameObject("handMain");
        guiImageObject.transform.SetParent(transform); // Make the Canvas the parent

        // Add the Image component to the GameObject
        Image guiImage = guiImageObject.AddComponent<Image>();

        // Optionally, set the image sprite
        // guiImage.sprite = yourSprite; // Replace "yourSprite" with your sprite reference

        // Set the position and size of the GUI Image (RectTransform)
        RectTransform rectTransform = guiImageObject.GetComponent<RectTransform>();
        float xOffset = -400f; // Adjust as needed
        float yOffset = 120f; // Adjust as needed
        rectTransform.anchoredPosition = new Vector2(xOffset + y*50f, yOffset);

        // Set the pivot to the upper-left corner
        rectTransform.pivot = Vector2.zero;

        // Adjust the size of the GUI Image as needed
        rectTransform.sizeDelta = new Vector2(40f, 40f); // Adjust as needed

        // FINGER PART

        // Create a new GameObject for the GUI Image
        GameObject fingerPart = new GameObject("handFinger");
        fingerPart.transform.SetParent(transform); // Make the Canvas the parent

        // Add the Image component to the GameObject
        Image FgiuImage = fingerPart.AddComponent<Image>();

        // Optionally, set the image sprite
        // guiImage.sprite = yourSprite; // Replace "yourSprite" with your sprite reference

        // Set the position and size of the GUI Image (RectTransform)
        RectTransform fingTra = fingerPart.GetComponent<RectTransform>();
        float fxOffset = -398f; // Adjust as needed
        float fyOffset = 86f; // Adjust as needed
        fingTra.anchoredPosition = new Vector2(fxOffset + y * 50f, fyOffset);

        // Set the pivot to the upper-left corner
        fingTra.pivot = Vector2.zero;

        // Adjust the size of the GUI Image as needed
        fingTra.sizeDelta = new Vector2(12f, 36f); // Adjust as needed
    }
}
