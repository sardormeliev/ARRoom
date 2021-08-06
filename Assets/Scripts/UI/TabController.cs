using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{

    public TabBarItem tabBarItem; 

    public void OnClickTab(TabBarItem tab) {

        if (tabBarItem != tab) {

            if (tabBarItem != null) {
                tabBarItem.SetOff();
            }

            tabBarItem = tab;

            tab.SetOn();
        }

    }



}
