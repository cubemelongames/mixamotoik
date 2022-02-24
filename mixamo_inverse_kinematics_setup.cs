using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class mixamo_inverse_kinematics_setup : MonoBehaviour
{
    InverseKinematics IKscript1, IKscript2, IKscript3, IKscript4;
    public GameObject helpersParent,
        right_arm_target, left_arm_target, right_leg_target, left_leg_target,
        right_arm_knee, left_arm_knee, right_leg_knee, left_leg_knee;
    public Transform RFoot1, LFoot1, RArm1, LArm1, Head1;
    public Transform RFoot2, LFoot2, RArm2, LArm2, Head2;
    public Transform RFoot3, LFoot3, RArm3, LArm3, Head3;
    Transform hiptransform;

    public void setupik()
    {
        get_IK_scripts();
        setupHelpers();
        getSkeletonparts();
        moveHelperstoPosition();
        IKScriptsetup();

    }

    private void IKScriptsetup()
    {
        IKscript1.target = right_arm_target.transform;
        IKscript2.target = left_arm_target.transform;
        IKscript3.target = right_leg_target.transform;
        IKscript4.target = left_leg_target.transform;

        IKscript1.elbow = right_arm_knee.transform;
        IKscript2.elbow = left_arm_knee.transform;
        IKscript3.elbow = right_leg_knee.transform;
        IKscript4.elbow = left_leg_knee.transform;
        ////////////////////////
        IKscript1.upperArm = RArm3;
        IKscript1.forearm = RArm2;
        IKscript1.hand = RArm1;

        IKscript1.uppperArm_OffsetRotation = new Vector3(0, 90, 90);
        IKscript1.forearm_OffsetRotation = new Vector3(-90, 180, 0);
        IKscript1.hand_OffsetRotation = new Vector3(90, 0, 0);

        IKscript2.upperArm = LArm3;
        IKscript2.forearm = LArm2;
        IKscript2.hand = LArm1;

        IKscript2.uppperArm_OffsetRotation = new Vector3(180, 90, 90);
        IKscript2.forearm_OffsetRotation = new Vector3(90, 0, 0);
        IKscript2.hand_OffsetRotation = new Vector3(90, 180, 0);
        ////////////////////////
        IKscript3.upperArm = RFoot3;
        IKscript3.forearm = RFoot2;
        IKscript3.hand = RFoot1;

        IKscript3.uppperArm_OffsetRotation = new Vector3(270,90,90);
        IKscript3.forearm_OffsetRotation = new Vector3(90,0,0);
        IKscript3.hand_OffsetRotation = new Vector3(-130, 90, 0);

        IKscript4.upperArm = LFoot3;
        IKscript4.forearm = LFoot2;
        IKscript4.hand = LFoot1;

        IKscript4.uppperArm_OffsetRotation = new Vector3(270,90,90);
        IKscript4.forearm_OffsetRotation = new Vector3(90,0,0);
        IKscript4.hand_OffsetRotation = new Vector3(230, 90, 0);

    }

    private void moveHelperstoPosition()
    {
        right_arm_target.transform.position = RArm1.position + transform.right / 5;
        left_arm_target.transform.position = LArm1.position - transform.right / 5;
        right_leg_target.transform.position = RFoot1.position - transform.up / 10;
        left_leg_target.transform.position = LFoot1.position - transform.up / 10;

        right_arm_knee.transform.position = RArm2.position - transform.forward / 3;
        left_arm_knee.transform.position = LArm2.position - transform.forward / 3;
        right_leg_knee.transform.position = RFoot2.position + transform.forward / 3;
        left_leg_knee.transform.position = LFoot2.position + transform.forward / 3;

        right_arm_target.transform.localEulerAngles = Vector3.up * (90 + transform.eulerAngles.y);
        left_arm_target.transform.localEulerAngles = Vector3.up * (90 + transform.eulerAngles.y);
        right_leg_target.transform.localEulerAngles = Vector3.up * (90+ transform.eulerAngles.y);
        left_leg_target.transform.localEulerAngles = Vector3.up * (90+ transform.eulerAngles.y);
    }

    private void getSkeletonparts()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name== "mixamorig:Hips")
            {
                hiptransform = transform.GetChild(i);
            }
        }
        if (hiptransform!=null)
        {
            RFoot1 = hiptransform.GetChild(1).GetChild(0).GetChild(0);
            RFoot2 = hiptransform.GetChild(1).GetChild(0);
            RFoot3 = hiptransform.GetChild(1);

            LFoot1 = hiptransform.GetChild(0).GetChild(0).GetChild(0);
            LFoot2 = hiptransform.GetChild(0).GetChild(0);
            LFoot3 = hiptransform.GetChild(0);

            RArm1 = hiptransform.GetChild(2).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0);
            RArm2 = hiptransform.GetChild(2).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0);
            RArm3 = hiptransform.GetChild(2).GetChild(0).GetChild(0).GetChild(2).GetChild(0);

            LArm1 = hiptransform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0);
            LArm2 = hiptransform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0);
            LArm3 = hiptransform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0);

            Head1 = hiptransform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetChild(0);
            Head2 = hiptransform.GetChild(2).GetChild(0).GetChild(0).GetChild(1);
            Head3 = hiptransform.GetChild(2).GetChild(0).GetChild(0);

        }
    }

    private void get_IK_scripts()
    {
        IKscript1 = GetComponents<InverseKinematics>()[0];
        IKscript2 = GetComponents<InverseKinematics>()[1];
        IKscript3 = GetComponents<InverseKinematics>()[2];
        IKscript4 = GetComponents<InverseKinematics>()[3];
    }

    private void setupHelpers()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "helpersParent")
            {
                helpersParent = transform.GetChild(i).gameObject;
                DestroyImmediate(helpersParent);
            }
        }

        helpersParent = new GameObject("helpersParent");
        helpersParent.transform.parent = transform;
        helpersParent.transform.localPosition = Vector3.zero;

        right_arm_target = new GameObject("right_arm_target"); ;
        right_arm_target.transform.parent = helpersParent.transform;
        right_arm_target.AddComponent<gizmo_helper>();

        left_arm_target = new GameObject("left_arm_target");
        left_arm_target.transform.parent = helpersParent.transform;
        left_arm_target.AddComponent<gizmo_helper>();

        right_leg_target = new GameObject("right_leg_target");
        right_leg_target.transform.parent = helpersParent.transform;
        right_leg_target.AddComponent<gizmo_helper>();

        left_leg_target = new GameObject("left_leg_target");
        left_leg_target.transform.parent = helpersParent.transform;
        left_leg_target.AddComponent<gizmo_helper>();

        right_arm_knee = new GameObject("right_arm_knee");
        right_arm_knee.transform.parent = helpersParent.transform;
        right_arm_knee.AddComponent<gizmo_helper>();
        right_arm_knee.GetComponent<gizmo_helper>().col = Color.green;


        left_arm_knee = new GameObject("left_arm_knee");
        left_arm_knee.transform.parent = helpersParent.transform;
        left_arm_knee.AddComponent<gizmo_helper>();
        left_arm_knee.GetComponent<gizmo_helper>().col = Color.green;

        right_leg_knee = new GameObject("right_leg_knee");
        right_leg_knee.transform.parent = helpersParent.transform;
        right_leg_knee.AddComponent<gizmo_helper>();
        right_leg_knee.GetComponent<gizmo_helper>().col = Color.green;

        left_leg_knee = new GameObject("left_leg_knee");
        left_leg_knee.transform.parent = helpersParent.transform;
        left_leg_knee.AddComponent<gizmo_helper>();
        left_leg_knee.GetComponent<gizmo_helper>().col = Color.green;

    }
}

[CustomEditor(typeof(mixamo_inverse_kinematics_setup))]
class DecalMeshHelperEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Setup"))
        {
            mixamo_inverse_kinematics_setup targetscript = (mixamo_inverse_kinematics_setup)target;
            targetscript.setupik();
        }
    }
}