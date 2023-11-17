using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabHandler : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject[] models;
    [SerializeField] GameObject pageArea;
    [SerializeField] ContentFiller cFiller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTabChange()
    {
        for(int i = 0; i < pageArea.transform.childCount; i++)
        {
            Destroy(pageArea.transform.GetChild(i).gameObject);
        }
        cFiller.content = sprites;
        cFiller.models = models;
        cFiller.PageAreaUpdate();
    }
}
