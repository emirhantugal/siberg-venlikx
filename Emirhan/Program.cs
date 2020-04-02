using System;
using System.Diagnostics;
using System.IO;

namespace Emirhan
{
    class Program
    {
        static void Main(string[] args)
        {

            ProcessStartInfo ps_nmap = new ProcessStartInfo();
            ps_nmap.RedirectStandardOutput = true;
            ps_nmap.RedirectStandardError = true;
            ps_nmap.FileName = "nmap";
            ps_nmap.Arguments = "-F 192.168.1.1";
            Process process_nmap = new Process();
            process_nmap.StartInfo = ps_nmap;
            process_nmap.Start();
            StreamWriter sr_out = new StreamWriter("nmap Emirhan.txt");
            StreamWriter sr_err = new StreamWriter("nmap error if exists.txt");
            StreamReader stdout = process_nmap.StandardOutput;
            StreamReader stderr = process_nmap.StandardError;
            sr_out.WriteLine(stdout.ReadToEnd());
            sr_err.WriteLine(stderr.ReadToEnd());
            sr_err.Close();
            sr_out.Close();
            process_nmap.WaitForExit();
            int nmap_exit_code = process_nmap.ExitCode;
            Console.WriteLine("nmap başarıyla çalıştı. Sonuc:" + nmap_exit_code);
            Console.ReadKey(true);
        }
    }
}
