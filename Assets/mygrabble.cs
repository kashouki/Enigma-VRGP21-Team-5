using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mygrabble : OVRGrabbable
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
    }
    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
    }
}
