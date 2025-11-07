using System;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

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
    public Transform playerArrow;

    public Transform player1;
    public Transform player2;
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
        if (playerNumber == 0)
        {
            playerArrow.transform.SetParent(player1);
        }
        else
        {
            playerArrow.transform.SetParent(player2);
        }
        playerArrow.localPosition = new Vector3(-200, 0, 0);
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
