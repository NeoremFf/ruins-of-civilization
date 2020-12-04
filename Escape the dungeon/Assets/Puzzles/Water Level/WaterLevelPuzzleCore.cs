using System.Collections.Generic;
using UnityEngine;

public class WaterLevelPuzzleCore : MonoBehaviour
{
    private class RuneStone
    {
        public readonly int MaxCountOfRunes;
        public int CurrentCountOfRunes
        {
            get
            {
                return currentCountOfRune;
            }

            set
            {
                currentCountOfRune = value;

                // Text
                
            }
        }
        private int currentCountOfRune;

        public int Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }
        private int position;

        public RuneStone(int maxCount, int currentCount, int position)
        {
            MaxCountOfRunes = maxCount;
            CurrentCountOfRunes = currentCount;
            Position = position;

            
        }
    }

    [Header("Ray")]
    [SerializeField]
    private Camera cameraToInteractive;
    [SerializeField]
    private LayerMask layerMaskToHit;

    [Header("Buttons")]
    [SerializeField]
    private GameObject buttonSwap_0;
    [SerializeField]
    private GameObject buttonSwap_1;
    [SerializeField]
    private GameObject buttonWaterPour;

    [Header("Stones Decore")]
    [SerializeField]
    private GameObject[] stonesGO;

    [Header("Need to win")]
    [Min(1)]
    [SerializeField]
    private int needToWin;

    private RuneStone[] runeStones = new RuneStone[3];
    private Dictionary<RuneStone, GameObject> runeStonePairs = new Dictionary<RuneStone, GameObject>();

    private void Start()
    {
        runeStones[0] = new RuneStone(6, 0, 0);
        runeStones[1] = new RuneStone(4, 4, 1);
        runeStones[2] = new RuneStone(5, 5, 2);

        for (int i = 0; i < 3; i++)
        {
            runeStonePairs.Add(runeStones[i], stonesGO[i]);
        }

        SetText(runeStones[0]);
        SetText(runeStones[1]);
        SetText(runeStones[2]);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cameraToInteractive.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10, layerMaskToHit))
            {
                GameObject hitButton = hit.collider.gameObject;
                
                // swap |* <-> * x|
                if (hitButton == buttonSwap_0)
                {
                    SwapRunes(runeStones[0], runeStones[1]);
                }
                // swap |x * <-> *|
                else if (hitButton == buttonSwap_1)
                {
                    SwapRunes(runeStones[1], runeStones[2]);
                }
                // pour water |* <- ^ x|
                else if (hitButton == buttonWaterPour)
                {
                    PourWater(runeStones[0], runeStones[1]);
                }

                // TODO
                if (CheckWin())
                {
                    gameObject.GetComponent<PuzzleManager>().PuzzleComplited();
                }
            }
        }
    }

    // Temp
    private void SwapRunes(RuneStone runeStone1, RuneStone runeStone2)
    {
        int tempRune = runeStone1.CurrentCountOfRunes;
        runeStone1.CurrentCountOfRunes = runeStone2.CurrentCountOfRunes;
        runeStone2.CurrentCountOfRunes = tempRune;
        
        SetText(runeStone1);
        SetText(runeStone2);
    }
    private void SetText(RuneStone runeStone)
    {
        GameObject textObject = runeStonePairs[runeStone];
        textObject.GetComponentInChildren<TextMesh>().text = runeStone.CurrentCountOfRunes.ToString();
    }

    private void PourWater(RuneStone leftRune, RuneStone rightRune)
    {
        while (leftRune.CurrentCountOfRunes != leftRune.MaxCountOfRunes &&
           rightRune.CurrentCountOfRunes != 0)
        {
            ++leftRune.CurrentCountOfRunes;
            --rightRune.CurrentCountOfRunes;
        }

        SetText(leftRune);
        SetText(rightRune);
    }

    private bool CheckWin()
    {
        return runeStones[0].CurrentCountOfRunes == needToWin;
    }

    // TODO
    private void SwapPosition(ref Vector3 pos1, ref Vector3 pos2)
    {

    }
}
