using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour, IState
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private DropController _dropController;
    [SerializeField] private GameObject _pauseButtonGMO;
    private Button _pauseButton;

    public void Enter()
    {
        Debug.Log("Entered Game state");
        //player null ise
        if (!_player)
        {
            Debug.LogError("PlayerController yok");
        }

        if (!_dropController)
        {
            Debug.LogError("DropController yok");
        }
        _pauseButtonGMO.SetActive(true);
        _pauseButton = _pauseButtonGMO.GetComponentInChildren<Button>();
        _pauseButton.onClick.AddListener(HandlePauseButton);
        _player.enabled = true;
        _player.SetCallBack(StopGameLoop);
        _dropController.enabled = true;


    }

    public void Exit()
    {
        _pauseButtonGMO.SetActive(false);
    }

    private void StopGameLoop()
    {
        _player.Reset();
        _player.enabled = false;
        _dropController.enabled = false;
    }

    private void HandlePauseButton()
    {
        FindObjectOfType<GameManager>().SetState(StateType.PauseGameState);
    }
}
