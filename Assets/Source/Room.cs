using AI.Interaction;
using UnityEngine;

public class Room : MonoBehaviour
{
    private void Awake()
    {
        SpottingManager = new SpottingManager();
    }

    public SpottingManager SpottingManager { get; private set; }
}
