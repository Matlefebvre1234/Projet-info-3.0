using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor (typeof (AIMouvement))]
//public class Editeur : Editor
//{
   //private void OnSceneGUI()
   //{
   //    AIMouvement fow = (AIMouvement)target;
   //    Handles.color = Color.white;
   //    Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.up, 360, fow.vuRad);
   //    Vector3 vuAngleA = fow.DirAngle(-fow.vuAngle / 2, false);
   //    Vector3 vuAngleB = fow.DirAngle(fow.vuAngle / 2, false);
   //
   //    Handles.DrawLine(fow.transform.position, fow.transform.position + vuAngleA * fow.vuRad);
   //    Handles.DrawLine(fow.transform.position, fow.transform.position + vuAngleB * fow.vuRad);
   //
   //    Handles.color = Color.red;
   //    foreach(Transform cible in fow.cibleVisisble)
   //    {
   //        Handles.DrawLine(fow.transform.position, cible.position);
   //    }
   //}
//}
