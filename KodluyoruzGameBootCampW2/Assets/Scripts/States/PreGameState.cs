using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreGameState : MonoBehaviour, IState
{
    [SerializeField] private GameObject _waitScreen;
    [SerializeField] private TextMeshProUGUI _waitText;

    private bool _isWaitingToStart;
    private Coroutine _coroutine;
    private InputController _inputController;


    public void Enter()
    {
        Debug.Log("Entered pregame game state");
        _inputController = new InputController(HandleInputResult);

        _isWaitingToStart = true;
        _coroutine = StartCoroutine(WaitForStart());
        _waitScreen.SetActive(true);
    }

    private void HandleInputResult()
    {
        FindObjectOfType<GameManager>().SetState(StateType.GameState);
    }

    public void Exit()
    {
        _isWaitingToStart = false;
        _inputController = null;
        StopCoroutine(_coroutine);
        _waitScreen.SetActive(false);
    }

    private void Update()
    {
        //boşluk tuşuna basıldığında PreGameState'den GameState'e geçiş sağlıyor;
        if (GameManager.GetCurrentState() != this) return;

        _inputController?.GetInput();
    }


    private IEnumerator WaitForStart()
    {
        float t = 0;

        while (_isWaitingToStart)
        {
            //val'i alfa değeri olarak oluşturuyoruz.
            var val = Mathf.PingPong(t, 0.5f) + 0.5f;
            //textin renginin değişmesini sağlıyor;
            _waitText.color = new Color(1, 1, 1, val);
            yield return null;
            t += Time.deltaTime;
        }
    }
}