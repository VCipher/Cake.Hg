using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing;

namespace Cake.Hg.Tests.Fakes
{
    public sealed class FakeCakeContext : ICakeContext
    {
        private readonly ICakeContext _context;

        public IFileSystem FileSystem => _context.FileSystem;
        public ICakeEnvironment Environment => _context.Environment;
        public IGlobber Globber => _context.Globber;
        public ICakeLog Log => _context.Log;
        public ICakeArguments Arguments => _context.Arguments;
        public IProcessRunner ProcessRunner => _context.ProcessRunner;
        public IRegistry Registry => _context.Registry;
        public IToolLocator Tools => _context.Tools;

        public FakeCakeContext()
        {
            var testsDir = new DirectoryPath(System.IO.Path.GetFullPath(AppContext.BaseDirectory));

            var fileSystem = new FileSystem();
            var environment = new FakeEnvironment(PlatformFamily.Windows);
            var globber = new Globber(fileSystem, environment);
            var log = new FakeLog();
            var args = new FakeCakeArguments();
            var processRunner = new ProcessRunner(environment, log);
            var registry = new WindowsRegistry();
            var toolRepo = new ToolRepository(environment);
            var config =
                new CakeConfigurationProvider(fileSystem, environment)
                    .CreateConfiguration(testsDir,
                        new Dictionary<string, string>());
            var toolResolutionStrategy = new ToolResolutionStrategy(fileSystem, environment, globber, config);
            var toolLocator = new ToolLocator(environment, toolRepo, toolResolutionStrategy);

            _context = new CakeContext(
                fileSystem, 
                environment, 
                globber, 
                log, 
                args, 
                processRunner, 
                registry,
                toolLocator);
            
            _context.Environment.WorkingDirectory = testsDir;
        }
    }
}