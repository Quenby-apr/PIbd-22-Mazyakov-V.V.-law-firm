using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LawFirmBusinessLogic.BindingModels;
using LawFirmBusinessLogic.Interfaces;
using LawFirmBusinessLogic.ViewModels;
using LawFirmDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace LawFirmDatabaseImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        WarehouseViewModel IWarehouseStorage.GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new LawFirmDatabase())
            {
                var Warehouse = context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName ||
                    rec.Id == model.Id);

                return Warehouse != null ?
                    new WarehouseViewModel
                    {
                        Id = Warehouse.Id,
                        WarehouseName = Warehouse.WarehouseName,
                        NameResponsiblePerson = Warehouse.NameResponsiblePerson,
                        DateCreate = Warehouse.DateCreate,
                        WarehouseComponents = Warehouse.WarehouseComponents
                            .ToDictionary(recWarehouseComponent => recWarehouseComponent.ComponentId,
                            recWarehouseComponent => (recWarehouseComponent.Component?.ComponentName,
                            recWarehouseComponent.Count))
                    } :
                    null;
            }
        }

        List<WarehouseViewModel> IWarehouseStorage.GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new LawFirmDatabase())
            {
                return context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
                    .ToList()
                    .Select(rec => new WarehouseViewModel
                    {
                        Id = rec.Id,
                        WarehouseName = rec.WarehouseName,
                        NameResponsiblePerson = rec.NameResponsiblePerson,
                        DateCreate = rec.DateCreate,
                        WarehouseComponents = rec.WarehouseComponents
                            .ToDictionary(recWarehouseComponent => recWarehouseComponent.ComponentId,
                            recWarehouseComponent => (recWarehouseComponent.Component?.ComponentName,
                            recWarehouseComponent.Count))
                    })
                    .ToList();
            }
        }

        List<WarehouseViewModel> IWarehouseStorage.GetFullList()
        {
            using (var context = new LawFirmDatabase())
            {
                return context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .ToList()
                    .Select(rec => new WarehouseViewModel
                    {
                        Id = rec.Id,
                        WarehouseName = rec.WarehouseName,
                        NameResponsiblePerson = rec.NameResponsiblePerson,
                        DateCreate = rec.DateCreate,
                        WarehouseComponents = rec.WarehouseComponents
                            .ToDictionary(recWarehouseComponents => recWarehouseComponents.ComponentId,
                            recWarehouseComponents => (recWarehouseComponents.Component?.ComponentName,
                            recWarehouseComponents.Count))
                    })
                    .ToList();
            }
        }

        void IWarehouseStorage.Insert(WarehouseBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Warehouse(), context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

       

        void IWarehouseStorage.Update(WarehouseBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var warehouse = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

                        if (warehouse == null)
                        {
                            throw new Exception("Склад не найден");
                        }

                        CreateModel(model, warehouse, context);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        void IWarehouseStorage.Delete(WarehouseBindingModel model)
        {

            using (var context = new LawFirmDatabase())
            {
                var warehouse = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

                if (warehouse == null)
                {
                    throw new Exception("Склад не найден");
                }

                context.Warehouses.Remove(warehouse);
                context.SaveChanges();
            }
        }
        bool IWarehouseStorage.CheckAndWriteOff(Dictionary<int, (string, int)> components, int countOfDocs)
        {
            using (var context = new LawFirmDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var warehouseComponent in components)
                        {
                            int count = warehouseComponent.Value.Item2 * countOfDocs;
                            IEnumerable<WarehouseComponent> warehouseComponents = context.WarehouseComponents
                                .Where(warehouse => warehouse.ComponentId == warehouseComponent.Key);

                            int totalCount = warehouseComponents.Sum(warehouse => warehouse.Count);
                            foreach (WarehouseComponent component in warehouseComponents)
                            {
                                if (component.Count <= count)
                                {
                                    count -= component.Count;
                                    context.WarehouseComponents.Remove(component);
                                    context.SaveChanges();
                                }

                                else
                                {
                                    component.Count -= count;
                                    context.SaveChanges();
                                    count = 0;
                                }

                                if (count == 0)
                                {
                                    break;
                                }
                            }
                            if (count!=0)
                            {
                                return false;
                            }
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse, LawFirmDatabase context)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.NameResponsiblePerson = model.NameResponsiblePerson;

            if (warehouse.Id == 0)
            {
                warehouse.DateCreate = DateTime.Now;
                context.Warehouses.Add(warehouse);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var WarehouseComponents = context.WarehouseComponents
                    .Where(rec => rec.WarehouseId == model.Id.Value)
                    .ToList();

                context.WarehouseComponents.RemoveRange(WarehouseComponents
                    .Where(rec => !model.WarehouseComponents.ContainsKey(rec.ComponentId))
                    .ToList());
                context.SaveChanges();

                foreach (var updateComponent in WarehouseComponents)
                {
                    updateComponent.Count = model.WarehouseComponents[updateComponent.ComponentId].Item2;
                    model.WarehouseComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }


            foreach (var WarehouseComponent in model.WarehouseComponents)
            {
                context.WarehouseComponents.Add(new WarehouseComponent
                {
                    WarehouseId = warehouse.Id,
                    ComponentId = WarehouseComponent.Key,
                    Count = WarehouseComponent.Value.Item2
                });
                context.SaveChanges();
            }

            return warehouse;
        }
    }
}
