using System;
using System.Collections.Generic;
using System.Linq;
using LawFirmBusinessLogic.BindingModels;
using LawFirmBusinessLogic.Interfaces;
using LawFirmBusinessLogic.ViewModels;
using LawFirmFileImplement.Models;

namespace LawFirmFileImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly FileDataListSingleton source;

        public WarehouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.NameResponsiblePerson = model.NameResponsiblePerson;

            foreach (var key in warehouse.WarehouseComponents.Keys.ToList())
            {
                if (!model.WarehouseComponents.ContainsKey(key))
                {
                    warehouse.WarehouseComponents.Remove(key);
                }
            }

            foreach (var component in model.WarehouseComponents)
            {
                if (warehouse.WarehouseComponents.ContainsKey(component.Key))
                {
                    warehouse.WarehouseComponents[component.Key] =
                        model.WarehouseComponents[component.Key].Item2;
                }
                else
                {
                    warehouse.WarehouseComponents.Add(component.Key, model.WarehouseComponents[component.Key].Item2);
                }
            }

            return warehouse;
        }

        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            Dictionary<int, (string, int)> warehouseComponents = new Dictionary<int, (string, int)>();

            foreach (var warehouseComponent in warehouse.WarehouseComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (warehouseComponent.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                warehouseComponents.Add(warehouseComponent.Key, (componentName, warehouseComponent.Value));
            }

            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                NameResponsiblePerson = warehouse.NameResponsiblePerson,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouseComponents
            };
        }

        public List<WarehouseViewModel> GetFullList()
        {
            return source.Warehouses.Select(CreateModel).ToList();
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return source.Warehouses.Where(recWarehouse => recWarehouse.WarehouseName.Contains(model.WarehouseName)).Select(CreateModel).ToList();
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var warehouse = source.Warehouses.FirstOrDefault(recWarehouse => recWarehouse.WarehouseName == model.WarehouseName || recWarehouse.Id == model.Id);

            return warehouse != null ? CreateModel(warehouse) : null;
        }

        public void Insert(WarehouseBindingModel model)
        {
            int maxId = source.Warehouses.Count > 0 ? source.Warehouses.Max(recWarehouse => recWarehouse.Id) : 0;
            var warehouse = new Warehouse { Id = maxId + 1, WarehouseComponents = new Dictionary<int, int>(), DateCreate = DateTime.Now };
            source.Warehouses.Add(CreateModel(model, warehouse));
        }

        public void Update(WarehouseBindingModel model)
        {
            var warehouse = source.Warehouses.FirstOrDefault(recWarehouse => recWarehouse.Id == model.Id);

            if (warehouse == null)
            {
                throw new Exception("Склад не найден");
            }

            CreateModel(model, warehouse);
        }

        public void Delete(WarehouseBindingModel model)
        {
            var Warehouse = source.Warehouses.FirstOrDefault(recWarehouse => recWarehouse.Id == model.Id);

            if (Warehouse != null)
            {
                source.Warehouses.Remove(Warehouse);
            }
            else
            {
                throw new Exception("Склад не найден");
            }
        }

        public bool CheckAndWriteOff(Dictionary<int, (string, int)> components, int countOfDocs)
        {
            foreach (var warehouseComponent in components)
            {
                int count = source.Warehouses.Where(component => component.WarehouseComponents.ContainsKey(warehouseComponent.Key))
                    .Sum(component => component.WarehouseComponents[warehouseComponent.Key]);

                if (count < warehouseComponent.Value.Item2 * countOfDocs)
                {
                    return false;
                }
            }

            foreach (var warehouseComponent in components)
            {
                int count = warehouseComponent.Value.Item2 * countOfDocs;
                IEnumerable<Warehouse> warehouses = source.Warehouses.Where(component => component.WarehouseComponents.ContainsKey(warehouseComponent.Key));

                foreach (Warehouse warehouse in warehouses)
                {
                    if (warehouse.WarehouseComponents[warehouseComponent.Key] <= count)
                    {
                        count -= warehouse.WarehouseComponents[warehouseComponent.Key];
                        warehouse.WarehouseComponents.Remove(warehouseComponent.Key);
                    }
                    else
                    {
                        warehouse.WarehouseComponents[warehouseComponent.Key] -= count;
                        count = 0;
                    }

                    if (count == 0)
                    {
                        break;
                    }
                }
            }
            return true;
        }
    }
}
