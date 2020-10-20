using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    const float _playerSpeed = 10f;
    [SerializeField] private PlayerModel _playerModel;
    [SerializeField] private GameObject healthBar;
    private Rigidbody rb;

    private HeathBarController _heathBarController;
    private CallBack _dieCallBack;

    public void SetCallBack(CallBack callBack)
    {
        _dieCallBack = callBack;
    }

    private void OnEnable()
    {
        Reset();
        rb = GetComponent<Rigidbody>();

        _playerModel = new PlayerModel(100);
        healthBar.SetActive(true);
        _heathBarController = healthBar.GetComponent<HeathBarController>();
        HealthVisualator();
    }

    private void OnDisable()
    {
        healthBar.SetActive(false);
        _dieCallBack = null;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        rb.velocity = movement * _playerSpeed;

    }

    public void ChangeHitPoint(int damege)
    {
        _playerModel.ChangeHitPoint(damege);
        if (_playerModel.GetHitPoint() == 0)
        {
            Die();
        }
        HealthVisualator();
    }

    private void Die()
    {
        _dieCallBack();
        FindObjectOfType<GameManager>().SetState(StateType.PreGameState);
    }

    private void HealthVisualator()
    {
        _heathBarController.UpdateSliderValue(_playerModel.GetHitPoint());
    }

    public void Reset()
    {
        gameObject.transform.position = Constants.START_POS;
    }
}
