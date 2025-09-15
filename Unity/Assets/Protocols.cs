using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Protocols : MonoBehaviour
{
    public class Packets
    {
        public class common
        {
            public int cmd;
            public string message;
        }

        public class req_data : common
        {
            public int id;
            public string data;
        }


        public class res_data : common
        {
            public req_data[] result;    //list or array 값을 받는다
        }
    }
}

   

