using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject red;
    [SerializeField] private GameObject blue;
    [SerializeField] private GameObject orange;
    [SerializeField] private GameObject yellow;
    [SerializeField] private GameObject black;

    [SerializeField] private GameObject green;
    
    [SerializeField] private Button btnRed;
    [SerializeField] private Button btnBlue;
    [SerializeField] private Button btnOrange;
    [SerializeField] private Button btnGreen;
    [SerializeField] private Button btnYellow;
    [SerializeField] private Button btnTiger;

    [SerializeField] private GameObject block;

    [SerializeField] private GameObject redShow;
    [SerializeField] private GameObject orangeShow;
    [SerializeField] private GameObject yellowShow;
    [SerializeField] private GameObject blueShow;
    [SerializeField] private GameObject greenShow;
    [SerializeField] private GameObject tigerShow;
    
    

    private int index = 0;
    private int level;
    private void Start()
    {
        btnRed.onClick.AddListener(() =>
        {
            RedClick();
        });
        
        btnBlue.onClick.AddListener(() =>
        {
            BlueClick();
        });
        
        btnOrange.onClick.AddListener(() =>
        {
            OrangeClick();
        });
        btnGreen.onClick.AddListener(() =>
        {
            GreenClick();
        });
        btnYellow.onClick.AddListener(() =>
        {
            YellowClick();
        });
        btnTiger.onClick.AddListener(() =>
        {
            TigerClick();
        });

        level = PlayerPrefs.GetInt("level", 0)+1;
        if (level == 1)
        {
            black.SetActive(true);
            btnGreen.transform.parent.gameObject.SetActive(false);
            btnTiger.transform.parent.gameObject.SetActive(false);
            btnRed.transform.parent.gameObject.SetActive(false);
        }
        
        if (level == 2)
        {
            btnGreen.transform.parent.gameObject.SetActive(false);
            btnRed.transform.parent.gameObject.SetActive(false);
        }
        
        if (level == 3)
        {
            btnRed.transform.parent.gameObject.SetActive(false);
        }
    }

    void RedClick()
    {
        block.SetActive(true);
        redShow.SetActive(true);
        Invoke(nameof(HideRed),0.5f);
    }

    void HideRed()
    {
        btnRed.transform.parent.gameObject.SetActive(false);
        red.SetActive(true);
        red.transform.SetSiblingIndex(index);
        index++;
        redShow.SetActive(false);
        block.SetActive(false);
        CheckWin();
    }
    
    void BlueClick()
    {
        block.SetActive(true);
        blueShow.SetActive(true);
        Invoke(nameof(HideBlue),0.5f);
    }

    void HideBlue()
    {
        btnBlue.transform.parent.gameObject.SetActive(false);
        blue.SetActive(true);
        blue.transform.SetSiblingIndex(index);
        index++;
        blueShow.SetActive(false);
        block.SetActive(false);
        CheckWin();
    }
    
    void OrangeClick()
    {
        block.SetActive(true);
        orangeShow.SetActive(true);
        Invoke(nameof(HideOrange),0.5f);
    }

    void HideOrange()
    {
        btnOrange.transform.parent.gameObject.SetActive(false);
        orangeShow.SetActive(false);
        orange.SetActive(true);
        orange.transform.SetSiblingIndex(index);
        index++;
        block.SetActive(false);
        CheckWin();
    }

    void YellowClick()
    {
        block.SetActive(true);
        yellowShow.SetActive(true);
        Invoke(nameof(HideYellow),0.5f);
    }

    void HideYellow()
    {
        btnYellow.transform.parent.gameObject.SetActive(false);
        yellow.SetActive(true);
        yellow.transform.SetSiblingIndex(index);
        index++;
        yellowShow.SetActive(false);
        block.SetActive(false);
        CheckWin();
    }
    
    void GreenClick()
    {
        block.SetActive(true);
        greenShow.SetActive(true);
        Invoke(nameof(HideGreen),0.5f);
    }

    void HideGreen()
    {
        btnGreen.transform.parent.gameObject.SetActive(false);
        green.SetActive(true);
        greenShow.SetActive(false);
        block.SetActive(false);
        index++;
        CheckWin();
    }
    
    void TigerClick()
    {
        block.SetActive(true);
        tigerShow.SetActive(true);
        Invoke(nameof(HideTiger),0.5f);
    }

    void HideTiger()
    {
        btnTiger.transform.parent.gameObject.SetActive(false);
        tigerShow.SetActive(false);
        black.SetActive(true);
        red.transform.SetSiblingIndex(index);
        index++;
        block.SetActive(false);
        CheckWin();
    }

    void CheckWin()
    {
        int count = 3;
        if (level == 2) count = 4;
        else if (level == 3) count = 5;
        else count = 3;
        if (index >= count)
        {
            if (level >= 3) level = 0;
            PlayerPrefs.SetInt("level",level);
            Invoke(nameof(ReloadLevel),1.5f);
        }
    }


    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
