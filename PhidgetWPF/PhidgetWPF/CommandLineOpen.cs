using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phidget22;

namespace PhidgetWPF
{
    public class CommandLineOpen
    {
        #region Events

        //public event EventHandler ExceptionThrown;

        #endregion

        #region Fields and Properties

        public string[] CommandLineOverride = null;

        public string[] CommandLine
        {
            get
            {
                return CommandLineOverride ?? Environment.GetCommandLineArgs();
            }
            set { CommandLineOverride = value; }
        }

        #endregion

        #region Relay Commands
        #endregion

        #region Constructors
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods

        public void OpenCmdLine(Phidget phidget)
        {
            string[] args = CommandLine;
            string appName = System.AppDomain.CurrentDomain.FriendlyName;
            int channel = 0;
            int serialNumber = Phidget.AnySerialNumber;
            string label = Phidget.AnyLabel;
            int hubPort = Phidget.AnyHubPort;
            bool isHubPort = false;
            string networkServerName = null;
            string password = null;
            string logFile = null;

            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].EndsWith(appName)) continue;
                    if (args[i].StartsWith("-"))
                    {
                        switch (args[i].Remove(0, 1).ToLower())
                        {
                            case "v": hubPort = int.Parse(args[++i]);
                                break;

                            case "c": channel = int.Parse(args[++i]);
                                break;

                            case "l": logFile = (args[++i]);
                                break;

                            case "L": label = args[++i];
                                break;

                            case "n": isHubPort = true;
                                break;

                            case "s":
                                phidget.IsRemote = true;
                                if (i == args.Length - 1) break;
                                if (args[++i] != null && !args[i].StartsWith("-"))
                                {
                                    networkServerName = args[i];
                                }
                                break;

                            case "p": password = args[++i];
                                break;

                            default: goto usage;
                        } 
                    } else goto usage;
                }

                if (logFile != null)
                {
                    Phidget22.Log.Enable(LogLevel.Info, logFile);
                }
                phidget.Channel = channel;
                phidget.DeviceSerialNumber = serialNumber;
                phidget.DeviceLabel = label;
                phidget.HubPort = hubPort;
                phidget.IsHubPortDevice = isHubPort;
                phidget.ServerName = networkServerName;

                if (phidget.IsRemote)
                {
                    Net.EnableServerDiscovery(ServerType.Device);
                    if (password != null && networkServerName != null)
                    {
                        Net.SetServerPassword(networkServerName, password);
                    }
                }
                else
                {
                    phidget.IsLocal = true;
                }
                phidget.Open();
                return;
            }

            catch (PhidgetException ex)
            {
                if (ex.ErrorCode == ErrorCode.Busy)
                {
                    return;
                }
            }
        usage:
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Invalid Command line arguments." + Environment.NewLine);
            stringBuilder.AppendLine("Usage: " + appName + " [Flags...]");
            stringBuilder.AppendLine("Flags:\t-n serialNumber: Serial Number, omit for any serial");
            stringBuilder.AppendLine("\t-l logFile: Enable phidget21 logging to logFile");
            stringBuilder.AppendLine("\t-v Port: Select the Port that the device is connected to. 0 by default");
            stringBuilder.AppendLine("\t-c deviceChannel: Select the specific channel of the device you want. 0 by default");
            stringBuilder.AppendLine("\t-h HubPort?: The device is connected to a hub port");
            stringBuilder.AppendLine("\t-s serverID\tServer Name, omit for any server");
            stringBuilder.AppendLine("\t-i ipAdress:port\tIp Address and Port. Port is optional, defaults to 5000");
            stringBuilder.AppendLine("\t-p password\tPassword, omit for no password" + Environment.NewLine);
            stringBuilder.AppendLine("Examples: ");
            stringBuilder.AppendLine(appName + " -n 50098 -h");
            stringBuilder.AppendLine(appName + " -n 1234567 -v 1 -c 0");
            stringBuilder.AppendLine(appName + "-r");
            stringBuilder.AppendLine(appName + " -s myphidgetserver");
            stringBuilder.AppendLine(appName + "-n 45670 -i 127.0.0.1:5001 -p password");
        }
    }

        #endregion
}
