using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SequenceEvent
{
    event System.Action finished;
    bool Started { get; }
}
