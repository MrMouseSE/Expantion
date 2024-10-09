using System;
using System.Collections.Generic;

namespace Unit
{
    [Serializable]
    public class UnitDescriptionsHolder
    {
        public UnitTypes UnitsType;
        public List<UnitDescriptionBlueprint> Blueprints;
    }
}