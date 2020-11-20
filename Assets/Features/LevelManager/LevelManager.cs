using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class LevelManager: MonoBehaviour
{
    [System.Serializable]
    public struct DifficultyLevelEntry {
        [SerializeField]
        public DifficultyLevel difficultyLevel;
        [SerializeField]
        public float duration;
    }
    
    public DifficultyLevelEntry[] difficulties;
    public float initialTimeout = 2.0f;

    private IEnumerator difficultyManagementCoroutine;

    public void Start()
    {
        difficultyManagementCoroutine = ManageDifficultyLevels();
        StartCoroutine(difficultyManagementCoroutine);
    }

    public void OnDisable()
    {
        StopCoroutine(difficultyManagementCoroutine);
    }

    IEnumerator ManageDifficultyLevels()
    {
        yield return new WaitForSeconds(initialTimeout);
        var i = 0;
        while (true)
        {
            // Activate difficulty level...
            difficulties[i].difficultyLevel.StartSpawnRoutine();
            
            // ... and wait.
            yield return new WaitForSeconds(difficulties[i].duration);
            
            // ... and deactivate the difficulty level.
            difficulties[i].difficultyLevel.StopSpawnRoutine();

            // Increase the iterator if there is another difficulty level available.
            if (i < difficulties.Length - 1)
            {
                i++;
            }
        }
    }
}
