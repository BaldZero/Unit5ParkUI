using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button difficultyButton;

    private GameManager gameManager;

    public GameObject titleScreen;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        difficultyButton = GetComponent<Button>();
        difficultyButton.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log(difficultyButton.gameObject.name + "was click");
        gameManager.StartGame(difficulty);

        titleScreen.gameObject.SetActive(false);
    }
}
