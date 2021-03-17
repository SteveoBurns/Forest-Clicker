using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [Header("Text boxes")]
    [SerializeField] private TextMeshProUGUI seedsText;
    [SerializeField] private TextMeshProUGUI seedsPerSecText;
    [SerializeField] private TextMeshProUGUI seedsButtonText;
    [SerializeField] private TextMeshProUGUI lureBirdText;
    [SerializeField] private TextMeshProUGUI plantTreeText;
    [SerializeField] private TextMeshProUGUI lureEagleText;
    [SerializeField] private TextMeshProUGUI befriendSquirrelsText;

    [Header("Buttons")]
    [SerializeField] private Button lureBirdButton;
    [SerializeField] private Button plantTreeButton;
    [SerializeField] private Button lureEagleButton;
    [SerializeField] private Button befriendSquirrelsButton;
     
    private double seeds;
    private double seedsValue;
    private double seedsPerSecond;
    private double lureBirdCost;
    private double plantTreeCost;
    private int plantTreeValue;
    private double lureEagleCost;
    private double befriendSquirrelsCost;
    private int befriendSquirrelsValue;

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

        plantTreeButton.gameObject.SetActive(false);            //
        lureEagleButton.gameObject.SetActive(false);            //Setting the buttons inactive at the start
        befriendSquirrelsButton.gameObject.SetActive(false);    //
    }

    // Update is called once per frame
    void Update()
    {
        seedsText.text = "Seeds: " + seeds.ToString("F0");          //Updating the seeds text
        SeedsButtonText();                                          //Calling the seeds text update function
        seeds += seedsPerSecond * Time.deltaTime;                   //Adding seeds/s to the seeds value

        //Setting the button texts
        lureBirdText.text = "Lure a bird\nAdds 1 seed per click\nCost: " + lureBirdCost.ToString("F0");
        plantTreeText.text = "Plant a tree\nCollect an extra 5 seeds/s\nCost: " + plantTreeCost.ToString("F0");
        lureEagleText.text = "Lure an eagle\nAdds 5 seeds per click\nCost: " + lureEagleCost.ToString("F0");
        befriendSquirrelsText.text = "Befriend squirrels\nCollect an extra 10 seeds/s\nCost: " + befriendSquirrelsCost.ToString("F0");


        if(seeds >= lureBirdCost)
        {
            lureBirdButton.interactable = true;                     //Sets the button to be active when afforable
        }
        else
        {
            lureBirdButton.interactable = false;                    //Sets the button non-interactable when unaffordable
        }

        InteractableButton(plantTreeCost, plantTreeButton);                     //
        InteractableButton(lureEagleCost, lureEagleButton);                     //Calling the functions for making the buttons interactable
        InteractableButton(befriendSquirrelsCost, befriendSquirrelsButton);     //
               
    }


    /// <summary>
    /// Setting the Collect seeds button text to change from singular to mutiples
    /// </summary>
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

    /// <summary>
    /// Adding seeds to the seedsValue variable.
    /// </summary>
    public void Click()
    {
        seeds += seedsValue;
        
    }

    /// <summary>
    /// The click function for the Lure Bird Button.
    /// Adds to seeds value variable
    /// Subtracts cost from seeds
    /// Updates the cost
    /// </summary>
    public void LureBirdClick()
    {
        if (seeds >= lureBirdCost)
        {
            seedsValue++;
            seeds -= lureBirdCost;
            lureBirdCost *= 1.4;

        }
    }

    /// <summary>
    /// The click function for the Plant Tree Button.
    /// Adds to seeds per second variable
    /// Subtracts cost from seeds
    /// Updates the cost
    /// Upates the seeds per second text
    /// </summary>
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

    /// <summary>
    /// The click function for the Lure Eagle Button.
    /// Adds to seeds value variable
    /// Subtracts cost from seeds
    /// Updates the cost
    /// </summary>
    public void LureEagleClick()
    {
        if (seeds >= lureEagleCost)
        {
            seedsValue += 5;
            seeds -= lureEagleCost;
            lureEagleCost *= 1.8;

        }
    }

    /// <summary>
    /// The click function for the Befriend Squirrels Button.
    /// Adds to seeds per second variable
    /// Subtracts cost from seeds
    /// Updates the cost
    /// Upates the seeds per second text
    /// </summary>
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

    /// <summary>
    /// Sets the button active & interactable when affordable and non-interactable when not affordable
    /// </summary>
    /// <param name="_cost">The cost of the button</param>
    /// <param name="_button">The button to make interactable</param>
    public void InteractableButton(double _cost, Button _button)
    {
        if (seeds >= _cost)
        {
            _button.gameObject.SetActive(true);     //Sets the button to be active when afforable
            _button.interactable = true;            //Sets the button interactable when affordable
        }
        else
        {
            _button.interactable = false;           //Sets the button non-interactable when unaffordable
        }
    }
}    
