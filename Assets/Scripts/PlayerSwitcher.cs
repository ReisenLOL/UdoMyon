using System;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    [Header("UI")] 
    public TextMeshProUGUI playerText;
    [Header("Players")]
    public PlayerController[] players;

    public CinemachineCamera cam;
    

    private void Update()
    {
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
        playerText.text = $"Player: {players[playerNumber].stats.entityName}";
        cam.Follow = players[playerNumber].transform;
        foreach (PlayerController player in players)
        {
            if (player != players[playerNumber] && player.enabled)
            {
                player.enabled = false;
                player.npcSelf.enabled = true;
                player.rb.linearVelocity = Vector2.zero;
            }
            else
            {
                player.enabled = true;
                player.npcSelf.enabled = false;
            }
        }
    }
}
