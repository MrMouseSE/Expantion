using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class UnitRandomizer
{
    public UnitTypes GetRandomUnitType(List<UnitTypes> currentTypes)
    {
        UnitTypes newType = (UnitTypes)0;
        while (!currentTypes.Contains(newType))
        {
            newType = (UnitTypes)Random.Range(0, Enum.GetValues(typeof(UnitTypes)).Length);
        }

        return newType;
    }
}