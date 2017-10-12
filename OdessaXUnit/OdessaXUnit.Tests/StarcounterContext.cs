using System;
using Starcounter;

namespace OdessaXUnit.Tests
{
    public static class StarcounterContext
    {
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