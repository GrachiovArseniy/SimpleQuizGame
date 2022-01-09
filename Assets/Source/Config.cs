using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Config")]
public class Config : ScriptableObject
{
    [SerializeField] private int _minLength;
    [SerializeField] private int _attempts;

    public int MinLength => _minLength;

    public int Attempts => _attempts;
}