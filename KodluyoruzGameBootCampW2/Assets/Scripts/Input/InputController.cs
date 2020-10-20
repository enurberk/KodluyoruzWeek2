using UnityEngine;
public class InputController
{
    readonly CallBack _callBack;

    public InputController(CallBack callBack)
    {
        _callBack = callBack;
    }
    public void GetInput()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _callBack();
        }
    }
}
