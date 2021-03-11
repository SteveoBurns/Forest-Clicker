using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI seedsText;
    [SerializeField] private TextMeshProUGUI seedsPerSecText;
    [SerializeField] private TextMeshProUGUI seedsButtonText; 

    private double seeds;
    private double seedsValue;

    // Start is called before the first frame update
    void Start()
    {
        seedsValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        seedsText.text = "Seeds: " + seeds.ToString();
        SeedsButtonText();

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
}
