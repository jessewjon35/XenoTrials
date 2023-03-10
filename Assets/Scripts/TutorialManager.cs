using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject player;

    public GameObject[] popUps;
    private int popUpIndex;
 
    public float startWaitTime = 1;


    public Button jumpButton;
    public Button shootButton;

    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        jumpButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < popUps.Length; i++)
        if(i == popUpIndex)
        {
                popUps[i].SetActive(true);
        }
        else
        {
                popUps[i].SetActive(false);
        }
        if(popUpIndex == 0)
        {
            
            if(joystick.Horizontal > 0f || joystick.Horizontal < 0f)
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 1)
        {
            jumpButton.gameObject.SetActive(true);

            if(player.transform.position.x >= 20)
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 2)
        {

        }

    }
    

}
