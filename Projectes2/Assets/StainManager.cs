using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> JumpList= new List<GameObject>();
    [SerializeField]
    private List<GameObject> DPSList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> HealList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> PortalList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> TimeList = new List<GameObject>();
    public int JumpLimiter, DpsLimiter, HealLimiter, PortalLimiter, TimeLimiter;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (JumpList.Count >= JumpLimiter+1)
        {
            Destroy(JumpList[0]);
            JumpList.RemoveAt(0);
        }
        if (DPSList.Count >= DpsLimiter + 1)
        {
            Destroy(DPSList[0]);
            DPSList.RemoveAt(0);
        }
        if (HealList.Count >= HealLimiter + 1)
        {
            Destroy(HealList[0]);
            HealList.RemoveAt(0);
        }
        if (TimeList.Count >= TimeLimiter + 1)
        {
            Destroy(TimeList[0]);
            TimeList.RemoveAt(0);
        }

    }
    public void newStain(GameObject stain,PaintColors color)
    {
        
        switch (color)
        {
            case PaintColors.red:
                DPSList.Add(stain);
                break;
            case PaintColors.cyan:
                HealList.Add(stain);
                break;
            case PaintColors.blue:
                PortalList.Add(stain);
                break;
            case PaintColors.yellow:
                JumpList.Add(stain);
                break;
            case PaintColors.orange:
                TimeList.Add(stain);
                break;
            case PaintColors.pink:
                //aqui no se puede llegar pero por si acaso:
                print(color);
                break;
           
            default:
                break;
        }
    }
}
