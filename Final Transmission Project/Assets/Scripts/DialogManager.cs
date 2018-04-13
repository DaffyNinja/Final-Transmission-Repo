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
    //public int lineNUm;

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

        //dialogText.text = "";

        isOptionSelect = false;

        optionsButtonObj1.SetActive(false);
        optionsButtonObj2.SetActive(false);
        optionsButtonObj3.SetActive(false);
        nextButton.SetActive(false);

        dialogText.text = "Hello?"; 

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
                    // dialog1 = true;
                    optionsButtonObj1.SetActive(true);
                    optionsButtonObj1.GetComponentInChildren<Text>().text = dScript.act1DialogOptions[0];

                    if (dialog1)
                    {
                        dialogText.text = dScript.act1OptionStoryText[0];
                        // optionsButtonObj1.SetActive(true);
                        currentAct += 1;
                        dialogLineNum = 0;
                        isOptionSelect = false;
                    }
                    break;

                case 2:
                    optionsButtonObj1.SetActive(true);
                    optionsButtonObj1.GetComponentInChildren<Text>().text = dScript.act2DialogOptions[0];

                    optionsButtonObj2.SetActive(true);
                    optionsButtonObj2.GetComponentInChildren<Text>().text = dScript.act2DialogOptions[1];

                    if (dialog1)
                    {
                        dialogText.text = dScript.act2OptionStoryText[0];
                        currentAct += 1;
                        dialogLineNum = 0;

                        isOptionSelect = false;
                    }
                    else if (dialog2)
                    {
                        dialogText.text = dScript.act2OptionStoryText[1];
                        currentAct += 1;
                        dialogLineNum = 0;

                        isOptionSelect = false;
                    }

                    break;

                case 3:
                    optionsButtonObj1.SetActive(true);
                    optionsButtonObj1.GetComponentInChildren<Text>().text = dScript.act3DialogOptions[0];

                    optionsButtonObj2.SetActive(true);
                    optionsButtonObj2.GetComponentInChildren<Text>().text = dScript.act3DialogOptions[1];

                    optionsButtonObj3.SetActive(true);
                    optionsButtonObj3.GetComponentInChildren<Text>().text = dScript.act3DialogOptions[2];

                    if (dialog1)
                    {
                        dialogText.text = dScript.act3OptionStoryText[0];

                        dialogLineNum = 0;

                        isOptionSelect = false;
                    }
                    else if (dialog2)
                    {
                        dialogText.text = dScript.act3OptionStoryText[1];

                        dialogLineNum = 0;

                        isOptionSelect = false;
                    }
                    else if (dialog3)
                    {
                        dialogText.text = dScript.act3OptionStoryText[2];

                        dialogLineNum = 0;

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

                timer = 0;
            }

           
            if (dialogLineNum >= dScript.act1DialogText.Length && currentAct == 1)
            {
                isOptionSelect = true;
            }

            if (dialogLineNum >= dScript.act2DialogText.Length && currentAct == 2)
            {
                isOptionSelect = true;
            }

            if (dialogLineNum >= dScript.act3DialogText.Length && currentAct == 3)
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
        // dialogLineNum += 1;
        timer = 0;

        switch (currentAct)
        {
            case 1:
                dialogText.text = dScript.act1DialogText[dialogLineNum];
                dialogLineNum += 1;
                break;

            case 2:
                dialogText.text = dScript.act2DialogText[dialogLineNum];
                dialogLineNum += 1;
                break;

            case 3:
                dialogText.text = dScript.act3DialogText[dialogLineNum];
                dialogLineNum += 1;
                break;
            default:
                print("ERROR!!!");
                break;
        }

        nextButton.SetActive(false);
    }
}
