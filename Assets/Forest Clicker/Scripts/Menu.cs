using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button startGame;

    public void OnClick()
    {
        SceneManager.LoadScene(1);
    }
}
