using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

namespace MiniMapOpacity
{

    public class Opacity : MelonMod
    {
        Color mmOpValue; //Variable to set the opacity amount
        Image mmOpLayer; //Image component of minimap bg layer
        GameObject mmBGLayer; //minimap bg object
        GameObject mmWrongBG; //wrong bg object for minimap
        GameObject mapObject; //drawn map object
        RectTransform mapLocation; //map object location
        int alphaValue = 0;

        
        public override void OnUpdate()
        {

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                mapObject = GameObject.Find("BWF/GameManager/GeneralGameManager/Minimap Folder/DMMap/DMMap Canvas/Map");
                mapLocation = GameObject.Find("BWF/GameManager/GeneralGameManager/Minimap Folder/DMMap/DMMap Canvas/Map").GetComponent<RectTransform>();
                if (mapLocation.localPosition.y == 0)
                {
                    mmBGLayer.SetActive(false);
                }
                else
                {
                    mmBGLayer.SetActive(true);
                }
            }

            if (Input.GetKeyDown(KeyCode.F8)) //toggle minimap opacity
            {
                mmWrongBG = GameObject.Find("GUI/Canvas (animated)/Minimap Holder/Minimap(Clone)/SquareMinimap/minimapBG");
                mmOpLayer = GameObject.Find("BWF/GameManager/GeneralGameManager/Minimap Folder/DMMap/DMMap Canvas/minimapBG").GetComponent<Image>();
                mmBGLayer = GameObject.Find("BWF/GameManager/GeneralGameManager/Minimap Folder/DMMap/DMMap Canvas/minimapBG");

                if (mmBGLayer.active == false)
                {
                    mmBGLayer.SetActive(true);
                    mmWrongBG.SetActive(false);
                    mmOpValue.g = 0f;
                    mmOpValue.b = 0f;
                    mmOpValue.r = 0f;
                    mmOpValue.a = 0.5f;
                    mmOpLayer.color = mmOpValue;
                    alphaValue = 5;
                }
                else
                {
                    mmBGLayer.SetActive(false);
                    mmWrongBG.SetActive(true);
                }
             
            }

            if (Input.GetKeyDown(KeyCode.F9)) //lower opacity value
            {
                if (alphaValue > 1)
                {
                    mmOpLayer = GameObject.Find("BWF/GameManager/GeneralGameManager/Minimap Folder/DMMap/DMMap Canvas/minimapBG").GetComponent<Image>();
                    mmBGLayer = GameObject.Find("BWF/GameManager/GeneralGameManager/Minimap Folder/DMMap/DMMap Canvas/minimapBG");
                    mmOpValue.g = 0f;
                    mmOpValue.b = 0f;
                    mmOpValue.r = 0f;
                    mmOpValue.a -= 0.100f;
                    mmOpLayer.color = mmOpValue;
                    alphaValue -= 1;
                }
                       
            }

            if (Input.GetKeyDown(KeyCode.F10)) //raise opacity value
            {
                if (alphaValue < 10)
                {
                    mmOpLayer = GameObject.Find("BWF/GameManager/GeneralGameManager/Minimap Folder/DMMap/DMMap Canvas/minimapBG").GetComponent<Image>();
                    mmBGLayer = GameObject.Find("BWF/GameManager/GeneralGameManager/Minimap Folder/DMMap/DMMap Canvas/minimapBG");
                    mmOpValue.g = 0f;
                    mmOpValue.b = 0f;
                    mmOpValue.r = 0f;
                    mmOpValue.a += 0.100f;
                    mmOpLayer.color = mmOpValue;
                    alphaValue += 1;
                }

            }
     
        }
   
    }
}
