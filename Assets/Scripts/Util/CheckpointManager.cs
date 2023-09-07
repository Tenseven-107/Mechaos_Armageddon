using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    List<Checkpoint> checkpoints = new List<Checkpoint>();
    int checkedPoints = 0;


    void Start()
    {
        checkpoints = transform.GetComponentsInChildren<Checkpoint>().ToList();
    }

    public bool CheckFinish()
    {
        foreach (var checkpoint in checkpoints)
        {
            if (checkpoint.activated == true)
            {
                checkedPoints++;
            }
            else checkedPoints--;
        }
        
        checkedPoints = Mathf.Clamp(checkedPoints, 0, checkpoints.Count);
        if (checkedPoints == checkpoints.Count) 
        {
            return true;
        }

        return false;
    }

    public void ResetCourse()
    {
        checkedPoints = 0;
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.ResetCheckpoint();
        }
    }
}
