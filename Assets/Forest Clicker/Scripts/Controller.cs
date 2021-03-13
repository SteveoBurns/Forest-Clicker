using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI seedsText;
    [SerializeField] private TextMeshProUGUI seedsPerSecText;
    [SerializeField] private TextMeshProUGUI seedsButtonText;
    [SerializeField] private TextMeshProUGUI lureBirdText;
    [SerializeField] private TextMeshProUGUI plantTreeText;
    [SerializeField] private TextMeshProUGUI lureEagleText;
    [SerializeField] private TextMeshProUGUI befriendSquirrelsText;

    [SerializeField] private GameObject plantTreeButton;
    [SerializeField] private GameObject lureEagleButton;
    [SerializeField] private GameObject befriendSquirrelsButton;

    private double seeds;
    private double seedsValue;
    private double seedsPerSecond;
    private double lureBirdCost;
    private double plantTreeCost;
    private double plantTreeValue;
    private double lureEagleCost;
    private double befriendSquirrelsCost;
    private double befriendSquirrelsValue;

    // Start is called before the first frame update
    void Start()
    {
        seedsValue = 1;
        lureBirdCost = 15;
        plantTreeValue = 5;
        plantTreeCost = 50;
        lureEagleCost = 100;
        befriendSquirrelsCost = 1000;
        befriendSquirrelsValue = 10;

        seedsPerSecText.text = "0 seeds/s";

        plantTreeButton.SetActive(false);
        lureEagleButton.SetActive(false);
        befriendSquirrelsButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        seedsText.text = "Seeds: " + seeds.ToString("F0");
        SeedsButtonText();
        seeds += seedsPerSecond * Time.deltaTime;


        lureBirdText.text = "Lure a bird\nAdds 1 seed per click\nCost: " + lureBirdCost.ToString("F0");
        plantTreeText.text = "Plant a tree\nCollect an extra 5 seeds/s\nCost: " + plantTreeCost.ToString("F0");
        lureEagleText.text = "Lure an eagle\nAdds 5 seeds per click\nCost: " + lureEagleCost.ToString("F0");
        befriendSquirrelsText.text = "Befriend squirrels\nCollect an extra 10 seeds/s\nCost: " + befriendSquirrelsCost.ToString("F0");

        if(seeds >= plantTreeCost)
        {
            plantTreeButton.SetActive(true);
        }

        if(seeds >= lureEagleCost)
        {
            lureEagleButton.SetActive(true);
        }
        
        if(seeds >= befriendSquirrelsCost)
        {
            befriendSquirrelsButton.SetActive(true);
        }

    }



    private void SeedsButtonText()
    {
        if (seedsValue <= 1)
        {
            seedsButtonText.text = "Collect " + seedsValue + " seed";
        }
        else
        {
            seedsButtonText.text = "Collect " + seedsValue + " seeds";
        }
    }

    public void Click()
    {
        seeds += seedsValue;
        
    }

    public void LureBirdClick()
    {
        if (seeds >= lureBirdCost)
        {
            seedsValue++;
            seeds -= lureBirdCost;
            lureBirdCost *= 1.4;

        }
    }

    public void PlantTreeClick()
    {
        if (seeds >= plantTreeCost)
        {
            seedsPerSecond += plantTreeValue;
            seeds -= plantTreeCost;
            plantTreeCost *= 1.8;
            seedsPerSecText.text = seedsPerSecond.ToString("F0") + " seeds/s";
        }
    }

    public void LureEagleClick()
    {
        if (seeds >= lureEagleCost)
        {
            seedsValue += 5;
            seeds -= lureEagleCost;
            lureEagleCost *= 1.8;

        }
    }

    public void BefriendSquirrelsClick()
    {
        if (seeds >= befriendSquirrelsCost)
        {
            seedsPerSecond += befriendSquirrelsValue;
            seeds -= befriendSquirrelsCost;
            befriendSquirrelsCost *= 2.1;
            seedsPerSecText.text = seedsPerSecond.ToString("F0") + " seeds/s";
        }
    }
}    
