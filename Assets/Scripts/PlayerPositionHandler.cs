using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionHandler : MonoBehaviour
{


    #region Condition
    Vector2 playerCurrentPosition;
    [SerializeField]Vector2 currentCheckpointPosition;

    public void OnCheckpoint(GameObject col)
    {
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPosition = newCheckpointPosition;
        SavePosition(currentCheckpointPosition);
    }
    public void OnEnemy()
    {
        ChangePlayerPosition(currentCheckpointPosition);
    }
    public void OnFinish(int newLevelUnlocked)
    {
        GameManager.Instance.ChangeLevel(newLevelUnlocked);
    }

    #endregion

    #region SaveLoad
    public TransformData playerPositionData;

    private void LoadPosition()
    {
        transform.position = playerPositionData.position;
    }
    
    private void SavePosition(Vector2 newPosition)
    {
        playerPositionData.position = newPosition;
    }
    #endregion
    
    #region Instruction
    private void ChangePlayerPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }
    #endregion

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
