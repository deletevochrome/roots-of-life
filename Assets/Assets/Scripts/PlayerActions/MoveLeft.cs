using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MoveRoot
{
    public MoveLeft()
    {
        m_direction = RootNode.Direction.Left;
        m_cost = 10.0f;
    }
}
