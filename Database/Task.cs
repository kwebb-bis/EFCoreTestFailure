using System;

namespace Database
{
    /// <summary>
    /// Database model class for tasks
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The type of task
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The username of the requesting user
        /// </summary>
        /// <remarks>
        /// Provides an at-a-glace view of who created this task
        /// </remarks>
        public string Username { get; set; }

        /// <summary>
        /// Status of the task
        /// </summary>
        /// <remarks>
        /// See Status.cs class for all supported statuses
        /// </remarks>
        public Status Status { get; set; }

        /// <summary>
        /// If supported, the progress complete of the task
        /// </summary>
        public int? ProgressPercent { get; set; }

        /// <summary>
        /// Date time of the task starting execution
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Date time of the task ending execution
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Date time of the last time the running task
        /// reported progress
        /// </summary>
        /// <remarks>
        /// The heartbeat process uses this to determine
        /// when a task is 'dead' and should be terminated.
        /// </remarks>
        public DateTime? LastProgressUpdate { get; set; }

        /// <summary>
        /// Active directory GUId of the requesting user
        /// </summary>
        public string UserAdId { get; set; }

        /// <summary>
        /// JSON-serialized task parameters object
        /// </summary>
        public string TaskDetails { get; set; }

        /// <summary>
        /// JSON-serialized progress object
        /// </summary>
        public string ProgressDetails { get; set; }
    }
}
