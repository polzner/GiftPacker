using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateSwitcher
{
    void Switch<T>() where T : BaseState;
    void Switch<T>(float delay) where T : BaseState;
}
