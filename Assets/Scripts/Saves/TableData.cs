using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem
{
    public class TableData
    {
        public TableData(string _id, Vector2 _ballStartPosition, Vector2[] _pegsPositions, BasketData[] _basketDatas)
        {

        }
        public string ID;
        public Vector2 BallStartPosition;
        public Vector2[] PegsPositions;
        public BasketData[] Baskets;
    }

}
