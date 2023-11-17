using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    [SerializeField] Vector3 initPos;
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] playActive;
    [SerializeField] GameObject[] buildActive;
    public bool isUIDragging = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayEnter()
    {
        foreach(GameObject go in playActive)
        {
            go.SetActive(true);
        }

        foreach (GameObject go in buildActive)
        {
            go.SetActive(false);
        }
        initPos = player.transform.position;
    }
    public void OnPlayExit()
    {
        foreach (GameObject go in playActive)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in buildActive)
        {
            go.SetActive(true);
        }
        player.transform.position = initPos;
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
