using System;
using UnityEngine;
using Quiz.Model;

public class InputHandlerPresenter : MonoBehaviour
{
    public void Init(InputHandler model)
    {
        _model = model;
    }

    private InputHandler _model;

    public void Input(string c)
    {
        _model.Input(Convert.ToChar(c));
    }
}
