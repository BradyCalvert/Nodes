using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NodesEditor : EditorWindow {
    Rect myRect = new Rect(10, 10, 100, 100);
    List<Rect> myWindows = new List<Rect > ();
    [MenuItem("Window/Node editor")]

 
static void ShowWindow()
    {
        NodesEditor editor = EditorWindow.GetWindow<NodesEditor>();
    }
    private void OnGUI()
    {
        if(myWindows.Count>1)
        {
            DrawNoxeCurve(myWindows[0], myWindows[1]);
        }
        if(GUILayout.Button("Add Node"))
            {
            myWindows.Add(new Rect(10, 20, 100, 100));
        }
        BeginWindows();
        for (int i = 0; i< myWindows.Count; i++)
        {
            //myRect = GUI.Window(0, myRect, DrawNodeWindow, "My Widnow");
            myWindows[i] = GUI.Window(i, myWindows[i], DrawNodeWindow, "My Window");
        }

        EndWindows();
    }

    void DrawNodeWindow(int id)
    {
        GUI.DragWindow();
    }
    void DrawNoxeCurve(Rect start, Rect end)
    {
        Vector3 starPos = new Vector3(start.x + start.width, start.y + (start.height / 2),0);
        Vector3 endPos = new Vector3(end.x, end.y + (end.height / 2), 0);
        Vector3 startTan = starPos + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Handles.DrawBezier(starPos, endPos, startTan, endTan, Color.blue,null,1);
    }

}
