using OpenKh.Common;
using McMaster.Extensions.CommandLineUtils;
using System;
using System.Reflection;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace OpenKh.Command.Bgad
{
    [Command("OpenKh.command.Arc")]
    [VersionOptionFromMember("--version", MemberName = nameof(GetVersion))]
    [Subcommand(
        typeof(UnpackCommand),
        typeof(PackCommand),
        typeof(ListCommand))]
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CommandLineApplication.Execute<Program>(args);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file {e.FileName} cannot be found. The program will now exit.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"FATAL ERROR: {e.Message}\n{e.StackTrace}");
            }
        }

        private static string GetVersion()
            => typeof(Program).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

        protected int OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();
            return 1;
        }

        [Command(Description = "Unpack the content of a BGAD archive")]
        private class UnpackCommand
        {
            protected int OnExecute(CommandLineApplication app)
            {
                return 0;
            }
        }

        [Command(Description = "Generate BGAD archive from directory")]
        private class PackCommand
        {
            protected int OnExecute(CommandLineApplication app)
            {
                return 0;
            }
        }

        [Command(Description = "Print content of a BGAD archive")]
        private class ListCommand
        {
            [Required]
            [FileExists]
            [Argument(0)]
            public string InputBgad { get; set; }

            protected int OnExecute(CommandLineApplication app)
            {
                return 0;
            }
        }
    }
}
