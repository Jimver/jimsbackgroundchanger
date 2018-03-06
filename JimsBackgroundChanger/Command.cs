using System.Collections.Generic;
using System.Diagnostics;

namespace JimsBackgroundChanger
{
    public class Command
    {
        public class Result
        {
            public int ExitCode { get; }
            public string Error { get; }
            public string Output { get; }

            public Result(int exitCode, string error, string output)
            {
                ExitCode = exitCode;
                Error = error;
                Output = output;
            }

            public override bool Equals(object obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((Result)obj);
            }

            protected bool Equals(Result other)
            {
                return ExitCode == other.ExitCode && string.Equals(Error, other.Error) && string.Equals(Output, other.Output);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = ExitCode;
                    hashCode = (hashCode * 397) ^ (Error != null ? Error.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Output != null ? Output.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }
        public static Result Run(string command, string args)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = command,
                Arguments = args,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();
            return new Result(process.ExitCode, error, output);
        }
    }
}