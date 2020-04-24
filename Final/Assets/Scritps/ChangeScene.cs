using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// namespaces are like folders for a single script
// helps prevent collisions with another persons scripts!
namespace scene
{
    public class ChangeScene : MonoBehaviour
    {
        // starts game from beginning 
        public void TryAgain()
        {
            //load the starting scene
            SceneManager.LoadScene("SampleScene");
        }
    }
}

