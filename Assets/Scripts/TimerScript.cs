using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{
    public Text TimerText; 
    public Text StartButtonText;
    public Text StepLeftTool;
    public Text StepCenterTool;
    public Text StepRightTool;
    public Text PipePosL;
    public Text PipePosC;
    public Text PipePosR;
    private float Timer = 60f;
    bool TimerRun = false;
    int Al, Bl, Cl, Ac, Bc, Cc, Ar, Br, Cr, RoundNumberL, RoundNumberC, RoundNumberR;

    public GameObject Water;
    public GameObject LeftPipe;
    public GameObject CenterPipe;
    public GameObject RightPipe;
    public GameObject LosePanel;
    public GameObject WinPanel;
    public Button StartButton;
    public Button LeftToolButton;
    public Button CenterToolButton;
    public Button RightToolButton;
    public Transform WaterFinish;
    public GameObject LeftJet;
    public GameObject LeftJet1;
    public GameObject LeftJet2;
    public GameObject RightJet;
    public GameObject RightJet1;
    public GameObject RightJet2;

    private void Start()
    {
        Al = 1;// UnityEngine.Random.Range(1, 2);
        Bl = UnityEngine.Random.Range(-2, -1);
        Cl = 0;// UnityEngine.Random.Range(-1, 1);
        Ac = -1;// UnityEngine.Random.Range(-2, 0);
        Bc = UnityEngine.Random.Range(1, 3);
        Cc = -1;// UnityEngine.Random.Range(-2, -1);
        Ar = UnityEngine.Random.Range(-3, -1);
        Br = 1;// UnityEngine.Random.Range(0, 2);
        Cr = 1;// UnityEngine.Random.Range(0, 2);

        RoundNumberL = UnityEngine.Random.Range(0, 11);
        RoundNumberC = UnityEngine.Random.Range(0, 11);
        RoundNumberR = UnityEngine.Random.Range(0, 11);


        TimerText.text = Timer.ToString();
        LeftPipe.transform.position = new Vector3(-1.647f, RoundNumberL, 0);
        CenterPipe.transform.position = new Vector3(-0.03f, RoundNumberC, 0);
        RightPipe.transform.position = new Vector3(1.59f, RoundNumberR, 0);
        if (RoundNumberL == 5)
        {
            LeftJet.SetActive(false);
            LeftJet1.SetActive(true);
        }
        else
        {
            LeftJet.SetActive(true);
            LeftJet1.SetActive(false);
        }

        if (RoundNumberR == 5)
        {
            RightJet.SetActive(false);
            RightJet1.SetActive(true);
        }
        else
        {
            RightJet.SetActive(true);
            RightJet1.SetActive(false);
        }
    }
    void Update()
    {
        if(TimerRun == true)
        {
            Timer -= Time.deltaTime;
            TimerText.text = Mathf.Round(Timer).ToString();
            transform.position = Vector3.MoveTowards(transform.position, WaterFinish.position, 0.0042f);
            if (Timer < 0)
            {
                TimerRun = false;
                TimerText.text = "Время вышло";
                LosePanel.SetActive(true);
                LeftToolButton.interactable = false;
                CenterToolButton.interactable = false;
                RightToolButton.interactable = false;
                StartButton.interactable = false;
            }
            if (RoundNumberL == 5 && RoundNumberC != 5 && RoundNumberR != 5)
            {
                //LeftJet.SetActive(false);
                //LeftJet1.SetActive(true);
                LeftJet.SetActive(false);
                LeftJet1.SetActive(true);
                LeftJet2.SetActive(false);
                RightJet.SetActive(true);
                RightJet1.SetActive(false);
                RightJet2.SetActive(false);
            }
            else if (RoundNumberL == 5 && RoundNumberC == 5 && RoundNumberR != 5)
            {
                LeftJet.SetActive(false);
                LeftJet1.SetActive(false);
                LeftJet2.SetActive(true);
                RightJet.SetActive(true);
                RightJet1.SetActive(false);
                RightJet2.SetActive(false);
            }
            else if (RoundNumberL == 5 && RoundNumberC == 5 && RoundNumberR == 5)
            {
                TimerRun = false;
                LeftJet.SetActive(false);
                LeftJet1.SetActive(false);
                LeftJet2.SetActive(false);
                RightJet.SetActive(false);
                RightJet1.SetActive(false);
                RightJet1.SetActive(false);
                WinPanel.SetActive(true);
                LeftToolButton.interactable = false;
                CenterToolButton.interactable = false;
                RightToolButton.interactable = false;
                StartButton.interactable = false;
            }
            else if (RoundNumberL != 5 && RoundNumberC == 5 && RoundNumberR != 5)
            {
                LeftJet.SetActive(true);
                LeftJet1.SetActive(false);
                LeftJet2.SetActive(false);
                RightJet.SetActive(true);
                RightJet1.SetActive(false);
                RightJet1.SetActive(false);
            }
            else if (RoundNumberL != 5 && RoundNumberC == 5 && RoundNumberR == 5)
            {
                LeftJet.SetActive(true);
                LeftJet1.SetActive(false);
                LeftJet2.SetActive(false);
                RightJet.SetActive(false);
                RightJet1.SetActive(false);
                RightJet2.SetActive(true);
            }
            else if (RoundNumberL == 5 && RoundNumberC != 5 && RoundNumberR == 5)
            {
                LeftJet.SetActive(false);
                LeftJet1.SetActive(true);
                LeftJet2.SetActive(false);
                RightJet.SetActive(false);
                RightJet1.SetActive(true);
                RightJet2.SetActive(false);
            }
            else if (RoundNumberL != 5 && RoundNumberC != 5 && RoundNumberR == 5)
            {
                //RightJet.SetActive(false);
                //RightJet1.SetActive(true);
                LeftJet.SetActive(true);
                LeftJet1.SetActive(false);
                LeftJet2.SetActive(false);
                RightJet.SetActive(false);
                RightJet1.SetActive(true);
                RightJet2.SetActive(false);
            }
            else
            {
                LeftJet.SetActive(true);
                LeftJet1.SetActive(false);
                LeftJet2.SetActive(false);
                RightJet.SetActive(true);
                RightJet1.SetActive(false);
                RightJet2.SetActive(false);
            }
        }
    }
    public void PressStart()
    {
        TimerRun = !TimerRun;
        //StartButtonText.text = TimerRun ? "Пауза" : "Старт";
        PipePosL.text = Convert.ToString(RoundNumberL);
        PipePosC.text = Convert.ToString(RoundNumberC);
        PipePosR.text = Convert.ToString(RoundNumberR);
        StepLeftTool.text = Convert.ToString($"{Al} | {Bl} | {Cl}");
        StepCenterTool.text = Convert.ToString($"{Ac} | {Bc} | {Cc}");
        StepRightTool.text = Convert.ToString($"{Ar} | {Br} | {Cr}");
        LeftToolButton.interactable = !LeftToolButton.interactable;
        CenterToolButton.interactable = !CenterToolButton.interactable;
        RightToolButton.interactable = !RightToolButton.interactable;
    }
    public void ButtonLeftTool()
    {
        RoundNumberL += Al;
        if (RoundNumberL > 10) RoundNumberL = 10;
        if (RoundNumberL < 0) RoundNumberL = 0;
        PipePosL.text = Convert.ToString(RoundNumberL);
        
        RoundNumberC += Bl;
        if (RoundNumberC > 10) RoundNumberC = 10;
        if (RoundNumberC < 0) RoundNumberC = 0;
        PipePosC.text = Convert.ToString(RoundNumberC);

        RoundNumberR += Cl;
        if (RoundNumberR > 10) RoundNumberR = 10;
        if (RoundNumberR < 0) RoundNumberR = 0;
        PipePosR.text = Convert.ToString(RoundNumberR);

        LeftPipe.transform.position = new Vector3(-1.647f, RoundNumberL, 0);
        CenterPipe.transform.position = new Vector3(-0.03f, RoundNumberC, 0);
        RightPipe.transform.position = new Vector3(1.59f, RoundNumberR, 0);
    }
    public void ButtonCenterTool()
    {
        RoundNumberL += Ac;
        if (RoundNumberL > 10) RoundNumberL = 10;
        if (RoundNumberL < 0) RoundNumberL = 0;
        PipePosL.text = Convert.ToString(RoundNumberL);
        
        RoundNumberC += Bc;
        if (RoundNumberC > 10) RoundNumberC = 10;
        if (RoundNumberC < 0) RoundNumberC = 0;
        PipePosC.text = Convert.ToString(RoundNumberC);
        
        RoundNumberR += Cc;
        if (RoundNumberR > 10) RoundNumberR = 10;
        if (RoundNumberR < 0) RoundNumberR = 0;
        PipePosR.text = Convert.ToString(RoundNumberR);

        LeftPipe.transform.position = new Vector3(-1.647f, RoundNumberL, 0);
        CenterPipe.transform.position = new Vector3(-0.03f, RoundNumberC, 0);
        RightPipe.transform.position = new Vector3(1.59f, RoundNumberR, 0);
    }
    public void ButtonRightTool()
    {
        RoundNumberL += Ar;
        if (RoundNumberL > 10) RoundNumberL = 10;
        if (RoundNumberL < 0) RoundNumberL = 0;
        PipePosL.text = Convert.ToString(RoundNumberL);
        
        RoundNumberC += Br;
        if (RoundNumberC > 10) RoundNumberC = 10;
        if (RoundNumberC < 0) RoundNumberC = 0;
        PipePosC.text = Convert.ToString(RoundNumberC);
        
        RoundNumberR += Cr;
        if (RoundNumberR > 10) RoundNumberR = 10;
        if (RoundNumberR < 0) RoundNumberR = 0;
        PipePosR.text = Convert.ToString(RoundNumberR);

        LeftPipe.transform.position = new Vector3(-1.647f, RoundNumberL, 0);
        CenterPipe.transform.position = new Vector3(-0.03f, RoundNumberC, 0);
        RightPipe.transform.position = new Vector3(1.59f, RoundNumberR, 0);
    }
    public void PressExit()
    {
        Timer = 60f;
        TimerRun = false;
        RoundNumberL = 7;
        RoundNumberC = 3;
        RoundNumberR = 5;
        LeftToolButton.interactable = false;
        CenterToolButton.interactable = false;
        RightToolButton.interactable = false;
        TimerText.text = Timer.ToString();
        Water.transform.position = new Vector3(0, -7, 0);
        LeftPipe.transform.position = new Vector3(-1.647f, RoundNumberL, 0);
        CenterPipe.transform.position = new Vector3(-0.03f, RoundNumberC, 0);
        RightPipe.transform.position = new Vector3(1.59f, RoundNumberR, 0);
        PipePosL.text = "";
        PipePosC.text = "";
        PipePosR.text = "";
        StepLeftTool.text = "";
        StepCenterTool.text = "";
        StepRightTool.text = "";
        if (RoundNumberL == 5)
        {
            LeftJet.SetActive(false);
            LeftJet1.SetActive(true);
        }
        else
        {
            LeftJet.SetActive(true);
            LeftJet1.SetActive(false);
        }

        if (RoundNumberR == 5)
        {
            RightJet.SetActive(false);
            RightJet1.SetActive(true);
        }
        else
        {
            RightJet.SetActive(true);
            RightJet1.SetActive(false);
        }
    }
}
