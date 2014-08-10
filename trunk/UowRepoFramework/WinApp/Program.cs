using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataAccess.Model;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using StructureMap;

namespace WinApp
{
    static class Program
    {
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

            ObjectFactory.Initialize(x =>
            {
                x.For<IDataContextAsync>().Use<DatabaseContext>();
                x.For<IRepositoryProvider>().Use<RepositoryProvider>()
                    .Ctor<RepositoryFactories>("repositoryFactories").Is(new RepositoryFactories());
                x.For<IUnitOfWork>().Use<UnitOfWork>();
                x.For(typeof(IRepositoryAsync<>)).Use(typeof(Repository<>));
            });

            Application.Run(new FrmMain());
        }
    }
}
