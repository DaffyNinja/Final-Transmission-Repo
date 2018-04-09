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
    public bool dialog1;
    public bool dialog2;
    public bool dialog3;

    public float timeTillNextDialog;
    public float timeTillOption;
    float timer;

    DialogScript dScript;

    // Use this for initialization
    void Awake()
    {
        dScript = GetComponent<DialogScript>();

        dialogText.text = "";

        isOptionSelect = false;

        currentAct = 1;
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
                    if (dialog1)
                    {
                        dialogText.text = dScript.act1DialogText[0];

                        isOptionSelect = false;
                    }
                    else if (dialog2)
                    {
                        dialogText.text = dialogText.text = dScript.act1DialogText[1];

                        isOptionSelect = false;
                    }
                    else if (dialog3)
                    {
                        dialogText.text = dialogText.text = dScript.act1DialogText[2];

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

            if (timer >= timeTillNextDialog)
            {
                dialogText.text = dScript.act1DialogText[0];
            }

            if (timer >= timeTillOption)
            {
                isOptionSelect = true;
            }
        }
    }

    public void DialogButton1()
    {
        dialog1 = true;
    }

    public void DialogButton2()
    {
        dialog2 = true;
    }

    public void DialogButton3()
    {
        dialog3 = true;
    }
}
