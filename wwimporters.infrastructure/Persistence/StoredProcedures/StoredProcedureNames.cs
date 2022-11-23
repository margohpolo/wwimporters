using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wwimporters.infrastructure.Persistence.StoredProcedures
{
    public class StoredProcedureNames
    {
        //TODO: Refactor to a single Dictionary after adding Query SPs
        public string[] AllStoredProcedures = new string[]
        {
            "Configuration_ApplyPartitioning",
            "Configuration_ApplyFullTextIndexing",
            "Configuration_ApplyAuditing",
            "Configuration_RemoveAuditing",
            "Configuration_ApplyRowLevelSecurity",
            "Configuration_RemoveRowLevelSecurity",
            "DeactivateTemporalTablesBeforeDataLoad",
            "ReactivateTemporalTablesAfterDataLoad"
        };

        public string[] SetupStoredProcedures = new string[]
        {
            "Configuration_ApplyPartitioning",
            "Configuration_ApplyFullTextIndexing"
        };

        public string[] QueryStoredProcedures = new string[]
        {

        };

        public string[] OtherStoredProcedures = new string[]
        {
            "Configuration_ApplyAuditing",
            "Configuration_RemoveAuditing",
            "Configuration_ApplyRowLevelSecurity",
            "Configuration_RemoveRowLevelSecurity",
            "DeactivateTemporalTablesBeforeDataLoad",
            "ReactivateTemporalTablesAfterDataLoad"
        };
    }
}
