using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public enum TypeTag
    {
        Player,
        Trap,
        Enemy,
        Checkpoint,
        Finish,
        Trigger,
    }
    public UnityEvent<GameObject> OnTrigger;
    public TypeTag targetTag;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log($"gameObject {gameObject.name} hit {col.gameObject.name}");
        if (col.tag == targetTag.ToString()) OnTrigger?.Invoke(col.gameObject);
    }
}
