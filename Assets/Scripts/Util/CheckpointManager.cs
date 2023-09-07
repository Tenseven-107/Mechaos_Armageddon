using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    List<Checkpoint> checkpoints = new List<Checkpoint>();


    void Start()
    {
        checkpoints = transform.GetComponentsInChildren<Checkpoint>().ToList();
    }

    public bool CheckFinish()
    {
        foreach (var checkpoint in checkpoints)
        {
            if (checkpoint.activated)
            {
                return true;
            }
            else return false;
        }
        return false;
    }

    public void ResetCourse()
    {
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.ResetCheckpoint();
        }
    }
}
