using System;
using System.Collections.Generic;
using System.Linq;
using Core.Business.Common;
using Core.Common.Exceptions;
using Core.DataAccess.Entities;

namespace Core.Business.Helpers
{
    public static class VersionChecker
    {
        public static void Check(ModelBase modelObject, EntityBase dbEntity)
        {
            var modelVersionable = modelObject as ModelEditVersionable;
            var dbEntityVersionable = dbEntity as EntityVersionable;

            if (modelVersionable != null && dbEntityVersionable != null)
            {
                Check(modelVersionable, dbEntityVersionable);
            }
        }

        public static void Check(ModelEditVersionable modelObject, EntityVersionable dbEntity)
        {
            var modelVersion = GetVersion(modelObject.RowVersion);
            var dbEntityVersion = GetVersion(dbEntity.RowVersion);

            if (!modelVersion.Equals(dbEntityVersion))
            {
                throw new ConcurrencyException("Concurrency error in " + dbEntity.GetType().Name);
            }
        }

        private static long GetVersion(IEnumerable<byte> rowVersion)
        {
            return BitConverter.ToInt64(rowVersion.Reverse().ToArray(), 0);
        }
    }
}