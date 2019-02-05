using NUnit.Framework;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.UITests
{
    [SetUpFixture]
    public class FixtureSetup
    {
        [OneTimeSetUp]
        public void Setup()
        {
            var logOutputDir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "TestResults",
                DateTime.Now.ToString("MM-dd-yyy_hh-mm-ss-tt"));
            Directory.CreateDirectory(logOutputDir);
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(Path.Combine(logOutputDir, "detailedLogs.txt"))
                .WriteTo.File(Path.Combine(logOutputDir, "logs.txt"), restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger();
            Log.Debug("Logger initialized");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Log.CloseAndFlush();
        }
    }
}
