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

    private double seeds;
    private double seedsValue;
    private double lureBirdCost;

    // Start is called before the first frame update
    void Start()
    {
        seedsValue = 1;
        lureBirdCost = 15;
    }

    // Update is called once per frame
    void Update()
    {
        seedsText.text = "Seeds: " + seeds.ToString("F0");
        SeedsButtonText();

        lureBirdText.text = "Lure a bird\nAdds 1 seed per click\nCost: " + lureBirdCost.ToString("F0");
    }



    private void SeedsButtonText()
    {
        if (seedsValue<=1)
        {
            seedsButtonText.text = "Get " + seedsValue + " seed";
        }
        else
        {
            seedsButtonText.text = "Get " + seedsValue + " seeds";
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
}
