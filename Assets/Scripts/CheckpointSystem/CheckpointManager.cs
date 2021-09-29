using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public CheckpointStage[] checkpointStages;
    static CheckpointManager _instance = null;

    int currentActiveCheckpointStage = 0;
    Dictionary<CheckpointTrigger, int> cp2NextStage;
    Dictionary<CheckpointTrigger, int> cp2CurrentStage;

    public static CheckpointManager Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            cp2NextStage = new Dictionary<CheckpointTrigger, int>();
            cp2CurrentStage = new Dictionary<CheckpointTrigger, int>();
        }
        else
        {
            Debug.LogError("[CheckpointManager] CheckpointManager should be a singleton!");
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < checkpointStages.Length; ++i)
        {
            int nextStageIndex = i + 1;
            foreach (var cpTrigger in checkpointStages[i].stageCheckpoints)
            {
                cp2NextStage.Add(cpTrigger, nextStageIndex);
                cp2CurrentStage.Add(cpTrigger, i);
                cpTrigger.triggerIsActive = false;
            }
        }

        foreach (var cpTrigger in checkpointStages[0].stageCheckpoints)
        {
            cpTrigger.triggerIsActive = true;
        }
    }

    public void OnCheckpointTriggered(CheckpointTrigger triggeredCheckpoint)
    {
        foreach (var nextStageCpTrigger in checkpointStages[currentActiveCheckpointStage].stageCheckpoints)
        {
            nextStageCpTrigger.triggerIsActive = false;
        }

        int nextStage = cp2NextStage[triggeredCheckpoint];
        if (nextStage >= checkpointStages.Length)
        {
            return;
        }

        foreach (var nextStageCpTrigger in checkpointStages[nextStage].stageCheckpoints)
        {
            nextStageCpTrigger.triggerIsActive = true;
        }

        currentActiveCheckpointStage = nextStage;
    }

}
