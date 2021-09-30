using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globle
{
    public static int globle = 1;
    public static string progressPath = Path.Combine(Application.persistentDataPath, "Progress");
    public static string progressFile = Path.Combine(progressPath, "ProgressFile");
    public Globle()
    {
        Debug.Log("Globle Construct");
    }
}

public enum FileOperationType
{
    Save = 1,
    Load = 2
}