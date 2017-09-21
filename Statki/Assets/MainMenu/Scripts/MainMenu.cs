using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public Texture backround;

    public bool story;

    public TextAsset file;
    
    void OnStart()
    {
        story = false;
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backround);
        GUIStyle style = new GUIStyle("TextField");
        style.fontSize = (int)(Screen.height * 0.08);
        style.alignment = TextAnchor.MiddleCenter;


        if (!story)
        {
            if (GUI.Button(new Rect(Screen.width * .375f, Screen.height * .45f, Screen.width * .25f, Screen.height * .12f), "New Game", style))
                story = true;
        }
        else
        {
            GUIStyle labelStyle = new GUIStyle("TextField");
            labelStyle.fontSize = (int)(Screen.height * 0.04);

            GUI.Label(new Rect(Screen.width * .1f, Screen.height * .05f, Screen.width * .8f, Screen.height * .7f), file.ToString(), labelStyle);

            if (GUI.Button(new Rect(Screen.width * .375f, Screen.height * .8f, Screen.width * .25f, Screen.height * .12f), "Play", style))
            {
                Application.LoadLevel("level1");
            }
        }
    }
}
