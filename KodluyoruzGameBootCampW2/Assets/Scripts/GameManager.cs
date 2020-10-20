using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] ile private olan bir nesne inspector de görünebilecek.
    //state leri listeledik.
    [SerializeField]
    private List<State> _gameStates = new List<State>();

    private static IState _currentState;

    private void Start()
    {
        SetState(StateType.PreGameState);
    }


    #region STATE MACHINE
    public void SetState(StateType stateType)
    {
        IState nextState = _gameStates.FirstOrDefault(x => x.stateType == stateType).stateScript as IState;

        if (_currentState == nextState) return;
        if (_currentState != null) _currentState.Exit();

        _currentState = nextState;
        nextState.Enter();
    }


    public static IState GetCurrentState()
    {
        return _currentState;
    }
    #endregion

}
//[System.Serializable] ile State classını serializeable yapıyoruz
[System.Serializable]
public class State
{
    public StateType stateType;
    public MonoBehaviour stateScript;
}
//Stateleri enum ile tuttuk.
public enum StateType
{
    PreGameState,
    GameState,
    PauseGameState
}
//delegate -> fonksşyonları tutmamızı sağlayan değişken;
//classsın dışına yazdık bu sayede herkes erişebilir;
public delegate void CallBack();