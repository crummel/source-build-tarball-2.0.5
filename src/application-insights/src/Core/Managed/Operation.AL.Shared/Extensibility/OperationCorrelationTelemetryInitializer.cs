﻿namespace Microsoft.ApplicationInsights.Extensibility
{
    using Implementation;
    using Microsoft.ApplicationInsights.Channel;

    /// <summary>
    /// Telemetry initializer that populates OperationContext for the telemetry item based on context stored in AsyncLocal variable.
    /// </summary>
    public class OperationCorrelationTelemetryInitializer : ITelemetryInitializer
    {
        /// <summary>
        /// Initializes/Adds operation id to the existing telemetry item.
        /// </summary>
        /// <param name="telemetryItem">Target telemetry item to add operation id.</param>
        public void Initialize(ITelemetry telemetryItem)
        {
            var itemContext = telemetryItem.Context.Operation;

            if (string.IsNullOrEmpty(itemContext.ParentId) || string.IsNullOrEmpty(itemContext.Id) || string.IsNullOrEmpty(itemContext.Name))
            {
                var parentContext = AsyncLocalHelpers.GetCurrentOperationContext();
                if (parentContext != null)
                {
                    if (string.IsNullOrEmpty(itemContext.ParentId)
                        && !string.IsNullOrEmpty(parentContext.ParentOperationId))
                    {
                        itemContext.ParentId = parentContext.ParentOperationId;
                    }

                    if (string.IsNullOrEmpty(itemContext.Id)
                        && !string.IsNullOrEmpty(parentContext.RootOperationId))
                    {
                        itemContext.Id = parentContext.RootOperationId;
                    }

                    if (string.IsNullOrEmpty(itemContext.Name)
                        && !string.IsNullOrEmpty(parentContext.RootOperationName))
                    {
                        itemContext.Name = parentContext.RootOperationName;
                    }
                }
            }
        }
    }
}
