namespace DabRadio
{
    using System;
    using System.Windows.Forms;

    using DabRadio.RadioFunctions;

    using MediatR;

    using StateMachine;

    using StructureMap;

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var container = Bootstrap();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.GetInstance<Main>());
        }

        public static Container Bootstrap()
        {
            var container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType<IMediator>();
                    scanner.TheCallingAssembly();
                    scanner.WithDefaultConventions();
                    scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));
                });

                cfg.For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
                cfg.For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));

                cfg.For<Main>().Use<Main>();
                cfg.For<IRadioStateMachine>().Use<RadioStateMachine>().Singleton();
                cfg.For<IRadioCommandDispatcher>().Use<RadioCommandDispatcher>().Singleton();
            });

            var whatDoIHave = container.WhatDoIHave();

            return container;
        }
    }
}
