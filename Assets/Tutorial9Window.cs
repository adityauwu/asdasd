using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tutorial9Window : EditorWindow
{
   bool placeObjects = true;
   GameObject objectToInstantiate;
   
   
   
   
   
    [MenuItem ("Window/My Window")]
   //after this line funtion would be executed first
   
    static void Init(){
Tutorial9Window window = (Tutorial9Window)EditorWindow.GetWindow(typeof(Tutorial9Window));
//window of type t9window is created with inbuilt funtion

window.Show();
    //window shown with this method;
    }

 void OnEnable(){
     SceneView.duringSceneGui -= CustomUpdate;
     SceneView.duringSceneGui += CustomUpdate;
 }





 void OnGUI(){
Debug.Log("help");
    placeObjects = EditorGUILayout.Toggle(placeObjects);
    objectToInstantiate = (GameObject)EditorGUILayout.ObjectField(objectToInstantiate,typeof(GameObject),true);

}

void CustomUpdate(UnityEditor.SceneView sv){
    Event e= Event.current;
if((e.type == EventType.MouseDrag || e.type == EventType.MouseDown) && e.button == 0){


RaycastHit  hit;
 int layer= 1<<8;
 
 if(Physics.Raycast(Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, Camera.current.pixelHeight - e.mousePosition.y, 0)), out hit, Mathf.Infinity, layer )){

     GameObject placedObject =(GameObject)PrefabUtility.InstantiatePrefab(PrefabUtility.GetCorrespondingObjectFromSource(objectToInstantiate));
 placedObject.transform.position = hit.point;
 placedObject.transform.localScale = new Vector3(1,1,1) * Random.Range(0.5f,2.0f);
 
 
 
 }

}


e.Use();
}

}



/* void OnEnable(){
     SceneView.onSceneGUIDelegate -= CustomUpdate;
     SceneView.onSceneGUIDelegate += CustomUpdate;
 } 

//whenever wondow is opened gui will run
 

void CustomUpdate(UnityEditor.SceneView sv){
    Event e= Event.current;
if((e.type == EventType.MouseDrag || e.type == EventType.MouseDown) && e.button == 0){
RaycastHit  hit;
 if(Physics.Raycast(Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, Camera.current.pixelHeight - e.mousePosition.y, 0)), out hit, Mathf.Infinity, ~LayerMask.NameToLayer("cube") )){

     GameObject placedObject =(GameObject)PrefabUtility.InstantiatePrefab(PrefabUtility.GetPrefabParent(objectToInstantiate));
 placedObject.transform.position = hit.point;
 placedObject.transform.localScale = new Vector3(1,1,1) * Random.Range(0.5f,2.0f);
 
 
 
 }




e.Use();
} */

