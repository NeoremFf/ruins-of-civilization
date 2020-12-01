using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject puzzle;

    public void PuzzleStarted()
    {
        puzzle.SetActive(true);
    }

    public void PuzzleCanceled()
    {
        puzzle.SetActive(false);
    }

    public void PuzzleComplited()
    {
        puzzle.SetActive(false);
    }
}
