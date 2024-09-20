using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   public void MoveTheScene(int SceneID)
   {
        SceneManager.LoadScene(SceneID);
   }

   public void Quit()
   {
      Application.Quit();
   }
}
