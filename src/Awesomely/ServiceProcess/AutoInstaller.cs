using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Awesomely.ServiceProcess
{
    public abstract class AutoInstaller : Installer
    {
        protected abstract string GetServiceName();
        private readonly IContainer components = null;

        protected AutoInstaller()
        {
            Installers.Add(new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem,
                Password = null,
                Username = null
            });

            Installers.Add(new ServiceInstaller
            {
// ReSharper disable DoNotCallOverridableMethodsInConstructor
                ServiceName = GetServiceName()
// ReSharper restore DoNotCallOverridableMethodsInConstructor
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
