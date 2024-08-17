using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[CreateAssetMenu]
public class ObjectSO : ScriptableObject
{
    [Serializable]
    public class Objects
    {
        public string name;
        public Material Objectmaterail;
        public MeshFilter meshFilter;
        public string message;
    }

     public List<Objects> objects;

   
    Objects objectClass;
    public enum ObjectSelected
    {
        wall,
        sphere,
    }
    public static ObjectSelected objectSelected;

   

    public Objects GetObjectsSOClass()
    {
        switch (objectSelected)
        {
            default:
            case ObjectSelected.wall:
                return objects[0];

            case ObjectSelected.sphere:
                return objects[1];




        }
    }
}
