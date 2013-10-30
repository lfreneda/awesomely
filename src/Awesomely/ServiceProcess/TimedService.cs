using System;
using System.ServiceProcess;
using System.Timers;

namespace Awesomely.ServiceProcess
{
    public abstract partial class TimedService
    {

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ServiceName = GetServiceName();
        }

        #endregion
    }

    public abstract partial class TimedService : ServiceBase
    {
        private readonly Timer _timer;

        protected TimedService(int millisecondsInterval)
        {
            InitializeComponent();

            _timer = new Timer { Interval = millisecondsInterval };
            _timer.Elapsed += (o, a) =>
            {
                try
                {
                    _timer.Enabled = false;
                    Execute();
                }
                catch (Exception ex)
                {
                    LogError(ex);
                }
                finally
                {
                    _timer.Enabled = true;
                }
            };
        }

        protected abstract void Execute();
        protected abstract void LogError(Exception ex);
        protected abstract string GetServiceName();

        protected override void OnStart(string[] args)
        {
            try
            {
                _timer.Enabled = true;
                _timer.Start();
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        protected override void OnStop()
        {
            try
            {
                _timer.Enabled = false;
                _timer.Stop();
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }
    }
}