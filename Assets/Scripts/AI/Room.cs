using AI.Interaction;
using UnityEngine;

public class Room : MonoBehaviour
{
    public SpottingManager SpottingManager { get; private set; }

    private void Awake()
    {
        SpottingManager = new SpottingManager();
    }
}