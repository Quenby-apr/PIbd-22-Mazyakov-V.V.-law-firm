using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LawFirmBusinessLogic.BindingModels;
using LawFirmBusinessLogic.HelperModels;
using LawFirmBusinessLogic.Interfaces;
using LawFirmBusinessLogic.ViewModels;

namespace LawFirmBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly IDocumentStorage _documentStorage;
        private readonly IOrderStorage _orderStorage;
        public ReportLogic(IDocumentStorage documentStorage, IComponentStorage
componentStorage, IOrderStorage orderStorage)
        {
            _documentStorage = documentStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportDocumentComponentViewModel> GetDocumentComponent()
        {
            var components = _componentStorage.GetFullList();
            var documents = _documentStorage.GetFullList();
            var list = new List<ReportDocumentComponentViewModel>();
            foreach (var component in components)
            {
                var record = new ReportDocumentComponentViewModel
                {
                    ComponentName = component.ComponentName,
                    Documents = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var document in documents)
                {
                    if (document.DocumentComponents.ContainsKey(component.Id))
                    {
                        record.Documents.Add(new Tuple<string, int>(document.DocumentName,
                       document.DocumentComponents[component.Id].Item2));
                        record.TotalCount +=
                       document.DocumentComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                DocumentName = x.DocumentName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонентов",
                Components = _componentStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveDocumentComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонентов",
                DocumentComponents = GetDocumentComponent()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
