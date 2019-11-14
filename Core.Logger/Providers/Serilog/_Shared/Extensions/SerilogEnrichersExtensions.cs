using Serilog;
using Serilog.Configuration;
using System;

namespace Core.Logger
{
    public static class SerilogEnrichersExtensions
    {
        public static LoggerConfiguration WithThread(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration is null) 
                throw new ArgumentNullException(nameof(enrichmentConfiguration));

            return enrichmentConfiguration.With<ThreadEnricher>();
        }

        public static LoggerConfiguration WithMachineName(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration is null)
                throw new ArgumentNullException(nameof(enrichmentConfiguration));

            return enrichmentConfiguration.With<MachineNameEnricher>();
        }

        public static LoggerConfiguration WithProcess(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration is null)
                throw new ArgumentNullException(nameof(enrichmentConfiguration));

            return enrichmentConfiguration.With<ProcessEnricher>();
        }

        public static LoggerConfiguration WithSourceContext
        (
            this LoggerEnrichmentConfiguration enrichmentConfiguration,

            string sourceContext
        )
        {
            if (enrichmentConfiguration is null)
                throw new ArgumentNullException(nameof(enrichmentConfiguration));

            return enrichmentConfiguration.With(new SourceContextEnricher(sourceContext));
        }
    }
}
