using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBmanager_script
{
    public static string username;
    public static string score;

    public static bool LoggedIn {get {return username!=null;}}
    public static void LogOut()
    {
      username=null;
    }
}
