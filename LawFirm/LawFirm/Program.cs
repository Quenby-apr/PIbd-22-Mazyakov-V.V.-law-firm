﻿using System;
using System.Windows.Forms;
using LawFirmBusinessLogic.BusinessLogic;
using LawFirmBusinessLogic.BusinessLogics;
using LawFirmBusinessLogic.Interfaces;
using LawFirmDatabaseImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace LawFirmView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IComponentStorage, ComponentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientStorage, ClientStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDocumentStorage, DocumentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ComponentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<OrderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<DocumentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ClientLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
