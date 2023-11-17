using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GogoGaga.TME;

[RequireComponent(typeof(LeantweenCustomAnimator))]
public class BuildingPanelHandler : MonoBehaviour
{
    LeantweenCustomAnimator animationHandler;
    [SerializeField] Vector3 openVector;
    [SerializeField] Vector3 closeVector;
    bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        animationHandler = gameObject.GetComponent<LeantweenCustomAnimator>();
        animationHandler.end_vector = openVector;
    }

    public void OpenCloseBuildingPanel()
    {
        if(isOpened)
        {
            animationHandler.end_vector = closeVector;
            animationHandler.PlayAnimation();
            isOpened = false;
        }
        else
        {
            animationHandler.end_vector = openVector;
            animationHandler.PlayAnimation();
            isOpened = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
