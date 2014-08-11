using System;
using System.Windows.Forms;
using Common.DI;
using Common.Extensions;
using DataAccess;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using SimpleInjector;
using SimpleInjector.Extensions;

namespace WinApp
{
    static class Program
    {
        public static Container Container { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            Container = new Container();
            RegisterDataAccess(Container, Lifestyle.Transient);

            Application.Run(new FrmMain());
        }
        public static void RegisterDataAccess(this Container container, Lifestyle lifestyle)
        {
            container.Register<IDataContextAsync, DatabaseContext>(lifestyle);
            container.Register<IUnitOfWorkAsync, UnitOfWork>(lifestyle);
            container.RegisterSingle<IRepositoryProvider>(new RepositoryProvider(new RepositoryFactories()));
            container.RegisterOpenGeneric(typeof(IRepositoryAsync<>), typeof(Repository<>));
        }
    }
}
