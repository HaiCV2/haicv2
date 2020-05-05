using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;
using CFTWinAppCore.Task;
using CFTWinAppCore.Sequences;
using CFTWinAppCore.DataLog;
using LogLibrary;
using CFTWinAppCore.DeviceManager;
using CFTWinAppCore.DeviceManager.DUT;
using System.Net.NetworkInformation;
using System.Net;
using System.Drawing.Design;
using System.IO;
using FluentFTP;
using CFTWinAppCore.MES;
using Option;
using System.Security.Cryptography;

namespace TiviCheckingTestTask.Tasks
{
    [clsTaskMetaInfo("Move Google Keys", "clsMoveGoogleKeys", true)]
    public class clsMoveGoogleKeys : ITask
    {
        private string m_strDescription;
        private ISequenceManager m_IModuleTask = null;
        private bool m_bStopWhenFail = false;
        private ITraceData m_TraceService;
        private string m_strDisplayValue = string.Empty;
        public clsMoveGoogleKeys()
        {
            m_bStopWhenFail = true;
            AllowExcution = true;
            m_strDescription = "Move Google Keys";
            WaitTvPowerOnTimeOut = 40000;
            DelayTime = 1000;
            PathNameSource = "";
            PathNameMove = "";
        }
        [Browsable(false)]
        public string Name
        {
            get { return "clsMoveGoogleKeys"; }
        }
        [Category("General Option")]
        public string Description
        {
            get
            {
                return m_strDescription;
            }
            set
            {
                m_strDescription = value;
            }
        }
        [Category("General Option")]
        [DisplayName("Stop When Fail")]
        [SaveAtt()]
        public bool StopWhenFail
        {
            get
            {
                return m_bStopWhenFail;
            }
            set
            {
                m_bStopWhenFail = value;
            }
        }
        [Category("General Option")]
        [DisplayName("Allow Excution")]
        [SaveAtt()]
        public bool AllowExcution
        {
            set;
            get;
        }
        [Category("General Option")]
        [DisplayName("Must run when fail")]
        [SaveAtt()]
        public bool MustRunWhenFail
        {
            get;
            set;
        }
        public string GetDisplayValue()
        {
            return m_strDisplayValue;
        }
        public string GetDisplayMaxValue()
        {
            return "-";
        }
        public string GetDisplayMinValue()
        {
            return "-";
        }
        public string GetAddTaskDescription()
        {
            return string.Empty;
        }
        public TaskResult Excution(IDeviceManager DevManager)
        {
            ITvDevices tvDevices = null;
            IMESSystem mesSystem = null;
            bool bRet = false;
            try
            {
                tvDevices = (ITvDevices)DevManager.GetDevIOService(typeof(ITvDevices));
                mesSystem = (IMESSystem)DevManager.GetDevIOService((typeof(IMESSystem)));
                string scanSN = m_IModuleTask.GetSeqParameter("SN").ToString();
                string machineName = m_IModuleTask.GetSeqParameter("MachineName").ToString();
                string userName = m_IModuleTask.GetSeqParameter("UserName").ToString();
                string strSN = scanSN.Substring(1, 8);

                string str43KD6 = @"C:\\GoogleKeys\\43KD6600\\" + PathNameSource.Trim();
                string str49KE8 = @"C:\\GoogleKeys\\49KE8100\\" + PathNameSource.Trim();
                string str32LD6 = @"C:\\GoogleKeys\\32LD6900\\" + PathNameSource.Trim();
                string str43LD5 = @"C:\\GoogleKeys\\43LD5600\\" + PathNameSource.Trim();
                string str43LD6 = @"C:\\GoogleKeys\\43LD6900\\" + PathNameSource.Trim();
                string str50LD6 = @"C:\\GoogleKeys\\50LD6900\\" + PathNameSource.Trim();
                string str55LD6 = @"C:\\GoogleKeys\\55LD6900\\" + PathNameSource.Trim();
                string str65LD6 = @"C:\\GoogleKeys\\65LD6900\\" + PathNameSource.Trim();
                string str55LE8 = @"C:\\GoogleKeys\\55LE8900\\" + PathNameSource.Trim();
                string str65KO9 = @"C:\\GoogleKeys\\65KO9500\\" + PathNameSource.Trim();

                string strLocalKeyPath = string.Empty;
                string strLocalKeyPathMove = string.Empty;

                string str43KD6_Move = @"C:\\Backups\\43KD6600\\" + PathNameMove.Trim();
                string str49KE8_Move = @"C:\\Backups\\49KE8100\\" + PathNameMove.Trim();
                string str32LD6_Move = @"C:\\Backups\\32LD6900\\" + PathNameMove.Trim();
                string str43LD5_Move = @"C:\\Backups\\43LD5600\\" + PathNameMove.Trim();
                string str43LD6_Move = @"C:\\Backups\\43LD6900\\" + PathNameMove.Trim();
                string str50LD6_Move = @"C:\\Backups\\50LD6900\\" + PathNameMove.Trim();
                string str55LD6_Move = @"C:\\Backups\\55LD6900\\" + PathNameMove.Trim();
                string str65LD6_Move = @"C:\\Backups\\65LD6900\\" + PathNameMove.Trim();
                string str55LE8_Move = @"C:\\Backups\\55LE8900\\" + PathNameMove.Trim();
                string str65KO9_Move = @"C:\\Backups\\65KO9500\\" + PathNameMove.Trim();

                switch (strSN)
                {
                    case "43KD6600":
                        strLocalKeyPath = str43KD6;
                        strLocalKeyPathMove = str43KD6_Move;
                        break;
                    case "49KE8100":
                        strLocalKeyPath = str49KE8;
                        strLocalKeyPathMove = str49KE8_Move;
                        break;
                    case "32LD6900":
                        strLocalKeyPath = str32LD6;
                        strLocalKeyPathMove = str32LD6_Move;
                        break;
                    case "43LD5600":
                        strLocalKeyPath = str43LD5;
                        strLocalKeyPathMove = str43LD5_Move;
                        break;
                    case "43LD6900":
                        strLocalKeyPath = str43LD6;
                        strLocalKeyPathMove = str43LD6_Move;
                        break;
                    case "50LD6900":
                        strLocalKeyPath = str50LD6;
                        strLocalKeyPathMove = str50LD6_Move;
                        break;
                    case "55LD6900":
                        strLocalKeyPath = str55LD6;
                        strLocalKeyPathMove = str55LD6_Move;
                        break;
                    case "65LD6900":
                        strLocalKeyPath = str65LD6;
                        strLocalKeyPathMove = str65LD6_Move;
                        break;
                    case "55LE8900":
                        strLocalKeyPath = str55LE8;
                        strLocalKeyPathMove = str55LE8_Move;
                        break;
                    case "65KO9500":
                        strLocalKeyPath = str65KO9;
                        strLocalKeyPathMove = str65KO9_Move;
                        break;
                }
                //if (!Directory.Exists(strLocalKeyPath))
                //    Directory.CreateDirectory(strLocalKeyPath);

                if (!Directory.Exists(strLocalKeyPathMove))
                    Directory.CreateDirectory(strLocalKeyPathMove);
                string[] SourceFiles = Directory.GetFiles(strLocalKeyPath);

                foreach (string file in Directory.GetFiles(strLocalKeyPath))
                {
                    strLocalKeyPath = string.Format("{0}\\{1}", strLocalKeyPath, Path.GetFileName(file));
                    clsLogManager.LogReport("Move from: {0}", strLocalKeyPath);
                    break;
                }

                foreach (string sfile in SourceFiles)
                {
                    string fileName = Path.GetFileName(sfile);
                    string deskFile = Path.Combine(strLocalKeyPathMove, fileName);
                    File.Move(sfile, deskFile);
                    Thread.Sleep(DelayTime);
                    clsLogManager.LogReport("To --> {0}", strLocalKeyPathMove);
                    bRet = true;
                    break;
                }
                if (bRet)
                {
                    m_strDisplayValue = "PASS";
                    return TaskResult.PASS;
                }
                else
                {
                    m_strDisplayValue = "FAIL";
                    return TaskResult.FAIL;
                }
            }
            catch (System.Exception ex)
            {
                clsLogManager.LogError("Excution: {0}", ex.ToString());
                return TaskResult.FAIL;
            }
        }
        public void SetModuleTask(ISequenceManager Seq)
        {
            m_IModuleTask = Seq;
            m_TraceService = (ITraceData)m_IModuleTask.GetService(typeof(ITraceData));
        }

        public void ParaToXmlAtt(System.Xml.XmlNode paraNode)
        {
            clsSaveTaskParaHelper.SaveObj2XmlNodeAtt(paraNode, this);
        }

        public void ParaFromXmlAtt(System.Xml.XmlNode NodeData)
        {
            clsSaveTaskParaHelper.ParseObjParameter2XmlNode(NodeData, this);
        }

        public string GetParaInfor()
        {
            throw new NotImplementedException();
        }

        public ITask Clone()
        {
            clsMoveGoogleKeys task = new clsMoveGoogleKeys();
            clsSaveTaskParaHelper.CopyObjProperties(this, task);
            return task;
        }
        [Category("General Option")]
        [DisplayName("Delay Time (ms)")]
        [SaveAtt()]
        public int DelayTime { set; get; }
        [Category("General Option")]
        [DisplayName("Wait Tivi Power On Time Out (ms)")]
        [SaveAtt()]
        public int WaitTvPowerOnTimeOut { set; get; }
        [Category("Config Path Name")]
        [DisplayName("Path Name Source Of Google Key")]
        [SaveAtt()]
        public string PathNameSource { set; get; }
        [Category("Config Path Name")]
        [DisplayName("Path Name Move Of Google Key")]
        [SaveAtt()]
        public string PathNameMove { set; get; }
    }
}
