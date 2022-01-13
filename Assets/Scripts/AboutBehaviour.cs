using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutBehaviour : MonoBehaviour
{
   public void OpenURL(string url)
   {
      Application.OpenURL(url);
   }
}
