using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

public struct Gesture
{
    public string name;
    public List<Vector3> fingerDatas;
    public UnityEvent onDetected;
}

public class GestureDetector : MonoBehaviour
{
    public float threshold = 0.03f;
    public OVRSkeleton skeleton;
    public List<Gesture> gestures;

    void Save()
    {
        Gesture gesture = new Gesture();
        gesture.name = "new Gesture";
        List<Vector3> datas = new List<Vector3>();
        foreach (var bone in skeleton.Bones)
        {
            datas.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }
        gesture.fingerDatas = datas;
        gestures.Add(gesture);

    }

    Gesture Detect()
    {
        Gesture currentGesture = new Gesture();
        float currentMin = Mathf.Infinity;

        foreach (var gesture in gestures)
        {
            float totalDistance = 0;
            bool isDiscard = false;
            for (int i = 0; i < skeleton.Bones.Count; i++)
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(skeleton.Bones[i].Transform.position);
                float distance = Vector3.Distance(currentData, gesture.fingerDatas[i]);
                if (distance > threshold)
                {
                    isDiscard = true;
                    break;
                }
                totalDistance += distance;
            }
            if (!isDiscard && totalDistance < currentMin)
            {
                currentMin = totalDistance;
                currentGesture = gesture;
            }
        }

        return currentGesture;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Save();

        Gesture currentGesture = Detect();
        if (OVRPlugin.GetHandTrackingEnabled() && !currentGesture.Equals(new Gesture()))
        {
            currentGesture.onDetected.Invoke();
        }
    }
}
