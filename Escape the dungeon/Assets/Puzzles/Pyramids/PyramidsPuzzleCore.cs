using System.Collections.Generic;
using UnityEngine;

public class PyramidsPuzzleCore : MonoBehaviour
{
    private class Platform
    {
        public int Position { get; set; }

        private Sphere[] spheres = new Sphere[3];
        private int lastSphereId = -1;

        public Platform(int position, Sphere[] spheres = null)
        {
            Position = position;
            if (position == 0)
            {
                this.spheres = spheres;
                lastSphereId = 2;
            }
        }

        public int GetCountOfShperes()
        {
            int k = 0;
            foreach (var item in spheres)
            {
                if (item != null) ++k;
                else break;
            }
            return k;
        }

        public bool AddSphere(Sphere sphere)
        {
            if (lastSphereId == 2) return false;
            bool flage = false;
            if (lastSphereId == -1)
            {
                spheres[++lastSphereId] = sphere;
                flage = true;
            }
            else if (spheres[lastSphereId].CompareTo(sphere) > 0)
            {
                spheres[++lastSphereId] = sphere;
                flage = true;
            }
            return flage;
        }

        public Sphere GetSphere()
        {
            if (lastSphereId == -1) return null;
            return spheres[lastSphereId];
        }

        public Sphere RemoveSphere()
        {
            if (lastSphereId == -1) return null;
            Sphere s = spheres[lastSphereId];
            spheres[lastSphereId--] = null;
            return s;
        }

        public bool IsAllSpheresHere()
        {
            foreach (var item in spheres)
            {
                if (item == null) return false;
            }
            return true;
        }
    }

    private class Sphere : System.IComparable
    {
        public int Volume { get; set; }

        public Sphere(int volume)
        {
            Volume = volume;
        }

        public int CompareTo(object obj)
        {
            if (obj == null || this == null) return -1;
            Sphere compareSphere = obj as Sphere;
            if (compareSphere == null)
            {
                return 1;
            }

            if (Volume > compareSphere.Volume)
                return 1;
            else
                return -1;
        }
    }

    [SerializeField]
    private GameObject[] platformsGO = new GameObject[3];
    [SerializeField]
    private GameObject[] spheresGO = new GameObject[3];

    [SerializeField]
    private Camera cameraToInteractive = null;
    [SerializeField]
    private LayerMask layerMaskToHit;

    private Dictionary<GameObject, Platform> platformsPairs = new Dictionary<GameObject, Platform>();
    private Dictionary<Sphere, GameObject> spheresPairs = new Dictionary<Sphere, GameObject>();

    private GameObject linkToHitPlatform = null;

    private void Start()
    {
        Sphere[] spheres = new Sphere[3];
        for (int i = 0; i < 3; i++)
        {
            spheres[i] = new Sphere(2 - i);
            spheresPairs.Add(spheres[i], spheresGO[i]);
        }
        platformsPairs.Add(platformsGO[0], new Platform(0, spheres));
        for (int i = 1; i < 3; i++)
        {
            platformsPairs.Add(platformsGO[i], new Platform(i));
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // only platforms can be hit
            Ray ray = cameraToInteractive.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10, layerMaskToHit))
            {
                if (linkToHitPlatform == null)
                {
                    NoSelectedPlatform(hit.collider.gameObject);
                }
                else
                {
                    SelectedPlatformIs(hit.collider.gameObject);
                }
            }
        }
    }

    private void NoSelectedPlatform(GameObject platformHit)
    {
        GameObject tempObj = platformHit;
        if (platformsPairs[tempObj].GetCountOfShperes() == 0) return;
        linkToHitPlatform = tempObj;

        GameObject sphereObj = spheresPairs[platformsPairs[linkToHitPlatform].GetSphere()];
    }

    private void SelectedPlatformIs(GameObject platformHit)
    {
        GameObject hitPlatform = platformHit;
        Sphere sphereToAdd = platformsPairs[linkToHitPlatform].GetSphere();
        Platform platform = platformsPairs[hitPlatform];
        if (platform.AddSphere(sphereToAdd))
        {
            platformsPairs[linkToHitPlatform].RemoveSphere();
            spheresPairs[sphereToAdd].transform.position = hitPlatform.transform.position + (Vector3.up * (platform.GetCountOfShperes() * 0.5f));

            if (CheckWin(platform)) gameObject.GetComponent<PuzzleManager>().PuzzleComplited();
        }
        linkToHitPlatform = null;
    }

    // TODO
    private bool CheckWin(Platform platform)
    {
        if (platform.Position != 2) return false;
        return platform.IsAllSpheresHere();
    }
}