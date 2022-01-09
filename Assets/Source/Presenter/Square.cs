using UnityEngine;
using UnityEngine.UI;

public class Square : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void SetChar(char c)
    {
        _text.text = c.ToString();
    }

    public void Open()
    {
        _text.enabled = true;
    }

    public void Close()
    {
        _text.enabled = false;
    }
}
