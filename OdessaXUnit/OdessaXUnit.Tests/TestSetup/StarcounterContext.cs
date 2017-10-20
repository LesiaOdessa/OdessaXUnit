using System;
using Starcounter;

namespace OdessaXUnit.Tests
{
    public static class StarcounterContext
    {
        // Helper for database access since it needs both
        // ScheduleTask and Db.Transact to work
        public static void ScheduleTransact(Action action)
        {
            ScheduleTask(() => Db.Transact(action));
        }

        public static void ScheduleTask(Action action)
        {
            Exception taskException = null;

            Scheduling.ScheduleTask(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    taskException = ex;
                }
            }, true);

            if (taskException != null)
            {
                throw taskException;
            }
        }
    }
}