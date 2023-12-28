using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject disEndDisplay;
    public int distRun;
    public bool addingDis = false;
    void Update()
    {
        if (addingDis == false){
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }

    IEnumerator AddingDis(){
        distRun += 1;
        disDisplay.GetComponent<Text>().text = "" + distRun;
        disEndDisplay.GetComponent<Text>().text = "" + distRun;
        yield return new WaitForSeconds(0.25f);
        addingDis = false;
    }
}
