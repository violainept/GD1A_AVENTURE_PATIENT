using UnityEngine.SceneManagement;
using UnityEngine;

public class SpawnpointRef : MonoBehaviour
{
    public int spawnPointRef;
    public PlayerMovements getIndex;
    public int PreviousSceneIndex;

    private void Awake()
    {
        getIndex = GameObject.FindWithTag("Player").GetComponent<PlayerMovements>();
        PreviousSceneIndex = getIndex.previousSceneIndex;
        if (PreviousSceneIndex == spawnPointRef)
        {
            GameObject.FindWithTag("Player").transform.position = transform.position;
        }
    }
}