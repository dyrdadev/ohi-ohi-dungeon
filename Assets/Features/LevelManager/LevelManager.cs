using System;
using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public DifficultyLevelEntry[] difficulties;

    private IEnumerator difficultyManagementCoroutine;
    public float initialTimeout = 2.0f;

    public void Start()
    {
        difficultyManagementCoroutine = ManageDifficultyLevels();
        StartCoroutine(difficultyManagementCoroutine);
    }

    public void OnDisable()
    {
        StopCoroutine(difficultyManagementCoroutine);
    }

    private IEnumerator ManageDifficultyLevels()
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

    [Serializable]
    public struct DifficultyLevelEntry
    {
        [SerializeField] public DifficultyLevel difficultyLevel;
        [SerializeField] public float duration;
    }
}