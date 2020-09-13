using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Client : MonoBehaviour
{
    public AMFRequirements amfReqs = new AMFRequirements();

    public TextMeshProUGUI spawnedVehicle;
    private static IAMF GetAMF(AMFRequirements reqs)
    {
        AMFFactory _factory = new AMFFactory(reqs);
        return _factory.Create();
    }





    #region UI Setting Anim/Mech/Fail Requirements
    public void SetWingCount(int wingCount)
    {
        amfReqs.wingCount = wingCount * 2;//UI pass offset
    }

    public void SetIsMoving(bool isMoving)
    {
        amfReqs.bMoving = isMoving;
    }
    public void SetAMFType(int amfType)
    {
        amfReqs.amfType = (AMFType)amfType;
    }


    #endregion UI Setting Vehicle Requirements

    public void CreateAMF()
    {

        Destroy(GameObject.FindGameObjectWithTag("AMF")); //clear out last obj

        IAMF vhc = GetAMF(amfReqs);
        spawnedVehicle.text = "Spawned a: " + vhc.ToString();
    }

}
