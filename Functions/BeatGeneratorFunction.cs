using System;
using System.Collections.Generic;
using BeatGeneratorAPI.Const;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;


namespace BeatGeneratorFunction.Functions
{
    public class BeatGeneratorFunction
    {
        private readonly ILogger _logger;

        public BeatGeneratorFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BeatGeneratorFunction>();
        }

        // Timer trigger to run at 8:00, 12:30, and 17:00 UTC
        [FunctionName("UpdateConfiguration")]
        public static void Run([TimerTrigger("0 0 8,11,12,17 * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var currentTime = DateTime.UtcNow.TimeOfDay;

            if (DateTime.UtcNow.Hour == 8)
            {
                BeatGeneratorAPIConst.configuration[1] = "Bass Drum";
                BeatGeneratorAPIConst.configuration[3] = "kick";
                BeatGeneratorAPIConst.configuration[4] = "snare";
                BeatGeneratorAPIConst.configuration[12] = "cymbal";
            }
            else if (DateTime.UtcNow.Hour == 12 && DateTime.UtcNow.Minute == 30)
            {
                BeatGeneratorAPIConst.configuration[1] = "Low-Mid Tom";
                BeatGeneratorAPIConst.configuration[3] = "snare";
                BeatGeneratorAPIConst.configuration[4] = "Hi-Hat";
                BeatGeneratorAPIConst.configuration[12] = "cymbal";
            }
            else if (DateTime.UtcNow.Hour == 17)
            {
                BeatGeneratorAPIConst.configuration[1] = "Low Floor Tom";
                BeatGeneratorAPIConst.configuration[3] = "kick";
                BeatGeneratorAPIConst.configuration[4] = "snare";
                BeatGeneratorAPIConst.configuration[12] = "Hi-Hat";
            }
            else if (DateTime.UtcNow.Hour == 11 && DateTime.UtcNow.Minute == 12)
            {
                BeatGeneratorAPIConst.configuration[1] = "a";
                BeatGeneratorAPIConst.configuration[3] = "b";
                BeatGeneratorAPIConst.configuration[4] = "c";
                BeatGeneratorAPIConst.configuration[12] = "d";
            }

            log.LogInformation("Configuration updated successfully.");
        }
    }
}
