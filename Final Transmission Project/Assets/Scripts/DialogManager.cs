using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{

    public TMP_Text dialogText;

    public bool isOptionSelect;
    public bool dialog1;
    public bool dialog2;
    public bool dialog3;

    public float timeTillNextDialog;
    public float timeTillOption;
    float timer;

    // Use this for initialization
    void Awake()
    {
        dialogText.text = "Test";

        isOptionSelect = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        print(timer.ToString());

        if (isOptionSelect)
        {
            timer = 0;

            if (dialog1)
            {
                dialogText.text = "Option 1";

                isOptionSelect = false;
            }
            else if (dialog2)
            {
                dialogText.text = "Option 2";

                isOptionSelect = false;
            }
            else if (dialog3)
            {
                dialogText.text = "Option 3";

                isOptionSelect = false;
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
                dialogText.text = "Next Text";
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
