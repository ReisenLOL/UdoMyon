using System;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSwitcher : MonoBehaviour
{
    #region Statication
    public static PlayerSwitcher instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    [Header("UI")] 
    public Image primaryPlayerImage;
    public Image secondaryPlayerImage;
    public TextMeshProUGUI primaryPlayerName;
    public TextMeshProUGUI secondaryPlayerName;
    public Transform primaryPlayerHealthBar;
    public Transform secondaryPlayerHealthBar;
    [Header("Players")]
    public PlayerController[] players;
    public Camera cam;
    public CinemachineCamera cineCam;
    public Vector2 mouseWorldPos;

    private void Update()
    {
        mouseWorldPos =  cam.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,cam.nearClipPlane));
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchPlayer(0); //yeah that's right we're starting arrays from 1 nevermind that's too complicated
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchPlayer(1);
        }
    }

    private void SwitchPlayer(int playerNumber)
    {
        primaryPlayerImage.sprite = players[playerNumber].portrait; //this code sucks btw
        primaryPlayerName.text = players[playerNumber].name;
        players[playerNumber].stats.healthBar = primaryPlayerHealthBar;
        players[playerNumber].stats.UpdateHealthBar();
        if (playerNumber == 0)
        {
            secondaryPlayerImage.sprite = players[1].portrait; //this code also sucks btw
            secondaryPlayerName.text = players[1].name;
            players[1].stats.healthBar = secondaryPlayerHealthBar;
            players[1].stats.UpdateHealthBar();
        }
        else
        {
            secondaryPlayerImage.sprite = players[0].portrait; //this code still sucks btw
            secondaryPlayerName.text = players[0].name;
            players[0].stats.healthBar = secondaryPlayerHealthBar;
            players[0].stats.UpdateHealthBar();
        }
        cineCam.Follow = players[playerNumber].transform;
        foreach (PlayerController player in players)
        {
            if (player != players[playerNumber] && player.enabled)
            {
                player.enabled = false;
                player.npcSelf.enabled = true;
                player.rb.linearVelocity = Vector2.zero;
            }
            else if (player == players[playerNumber] && !player.enabled)
            {
                player.enabled = true;
                player.npcSelf.enabled = false;
            }
        }
    }
}
