using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [ContextMenu("Change Scene")]
    public void ChangeScene()
    {
        SceneManager.LoadScene("Scene2");
    }
}
