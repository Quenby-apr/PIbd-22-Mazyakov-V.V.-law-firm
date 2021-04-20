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
        private readonly IDocumentStorage _documentStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IComponentStorage _componentStorage;
        private readonly IWarehouseStorage _warehouseStorage;
        public ReportLogic(IDocumentStorage documentStorage, IOrderStorage orderStorage, IComponentStorage componentStorage, IWarehouseStorage warehouseStorage)
        {
            _documentStorage = documentStorage;
            _orderStorage = orderStorage;
            _componentStorage = componentStorage;
            _warehouseStorage = warehouseStorage;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportDocumentComponentViewModel> GetDocumentComponent()
        {
            var documents = _documentStorage.GetFullList();
            var list = new List<ReportDocumentComponentViewModel>();
            foreach (var document in documents)
            {
                var record = new ReportDocumentComponentViewModel
                {
                    DocumentName = document.DocumentName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in document.DocumentComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportWarehouseComponentViewModel> GetWarehouseComponents()
        {
            var warehouses = _warehouseStorage.GetFullList();
            var records = new List<ReportWarehouseComponentViewModel>();

            foreach (var warehouse in warehouses)
            {
                var record = new ReportWarehouseComponentViewModel
                {
                    WarehouseName = warehouse.WarehouseName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in warehouse.WarehouseComponents)
                {
                        record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                        record.TotalCount += component.Value.Item2;
                }
                records.Add(record);
            }
            return records;
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
        public List<ReportOrdersByDateViewModel> GetOrdersInfoByDate()
        {
            return _orderStorage.GetFullList()
                .GroupBy(order => order.DateCreate.ToShortDateString())
                .Select(rec => new ReportOrdersByDateViewModel
                {
                    Date = Convert.ToDateTime(rec.Key),
                    Count = rec.Count(),
                    Sum = rec.Sum(order => order.Sum)
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
                Title = "Список документов",
                Documents = _documentStorage.GetFullList()
            });
        }
        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateWarehouseDoc(new WordWarehouseInfo
            {
                FileName = model.FileName,
                Title = "Список складов:",
                Warehouses = _warehouseStorage.GetFullList()
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
                Title = "Список компонентов:",
                DocumentComponents = GetDocumentComponent()
            });
        }
        public void SaveWarehouseComponentsToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateWarehouseDoc(new ExcelWarehouseInfo
            {
                FileName = model.FileName,
                Title = "Список складов:",
                WarehouseComponents = GetWarehouseComponents()
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
        public void SaveOrdersInfoByDateToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateSummaryOrderInfoDoc(new PdfGeneralOrder
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrdersInfoByDate()
            });
        }
    }
}
