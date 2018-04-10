using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TMP_Text dialogText;

    public bool isOptionSelect;

    public int currentAct;
    bool dialog1;
    bool dialog2;
    bool dialog3;
    int dialogLineNum;

    [Space(5)]
    public float timeTillNextDialog;
    public float timeTillOption;
    float timer;
    [Space(5)]
    public GameObject optionsButtonObj1;
    public GameObject optionsButtonObj2;
    public GameObject optionsButtonObj3;
    public GameObject nextButton;

    DialogScript dScript;

    // Use this for initialization
    void Awake()
    {
        dScript = GetComponent<DialogScript>();

        dialogText.text = "";

        isOptionSelect = false;

        currentAct = 1;

        optionsButtonObj1.SetActive(false);
        optionsButtonObj2.SetActive(false);
        optionsButtonObj3.SetActive(false);
        nextButton.SetActive(false);

        dialogText.text = dScript.act1DialogText[dialogLineNum];

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        print(timer.ToString());

        if (isOptionSelect)
        {
            timer = 0;

            switch (currentAct)
            {
                case 1:
                    optionsButtonObj1.SetActive(true);
                    if (dialog1)
                    {
                        dialogText.text = dScript.act1DialogOptions[0];

                        isOptionSelect = false;
                    }
                    break;

                default:
                    print("ERROR!!");
                    break;
            }
        }
        else
        {
            timer += Time.fixedDeltaTime;

            dialog1 = false;
            dialog2 = false;
            dialog3 = false;

            optionsButtonObj1.SetActive(false);
            optionsButtonObj2.SetActive(false);
            optionsButtonObj3.SetActive(false);

            if (timer >= timeTillNextDialog)
            {
                nextButton.SetActive(true);
                dialogText.text = dScript.act1DialogText[dialogLineNum];

                timer = 0;
                
            }

            // CHange from timer based to change when dialog option line number is available
            if (timer >= timeTillOption)
            {
                isOptionSelect = true;
            }
        }
    }

    public void DialogButton1()
    {
        dialog1 = true;

        //currentAct += 1;
    }

    public void DialogButton2()
    {
        dialog2 = true;

        //currentAct += 1;
    }

    public void DialogButton3()
    {
        dialog3 = true;

        //currentAct += 1;
    }

    public void NextButton()
    {
        dialogLineNum += 1;
        timer = 0;
        nextButton.SetActive(false);
    }
}
