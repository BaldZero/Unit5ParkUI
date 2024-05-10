using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeGame : MonoBehaviour
{
    private GameManager gameManager;
    private Button resume;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        resume = GetComponent<Button>();
        resume.onClick.AddListener(Resume);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Resume()
    {
        Time.timeScale = 1;
        gameManager.pauseScreen.gameObject.SetActive (false);
    }


}
