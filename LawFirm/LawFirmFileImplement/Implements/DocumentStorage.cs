
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LawFirmBusinessLogic.BindingModels;
using LawFirmBusinessLogic.Interfaces;
using LawFirmBusinessLogic.ViewModels;
using LawFirmFileImplement.Models;

namespace LawFirmFileImplement.Implements
{
    public class DocumentStorage : IDocumentStorage
    {
        private readonly FileDataListSingleton source;
        public DocumentStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<DocumentViewModel> GetFullList()
        {
            return source.Documents
            .Select(CreateModel)
            .ToList();
        }
        public List<DocumentViewModel> GetFilteredList(DocumentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Documents
            .Where(rec => rec.DocumentName.Contains(model.DocumentName))
            .Select(CreateModel)
            .ToList();
        }
        public DocumentViewModel GetElement(DocumentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var document = source.Documents
            .FirstOrDefault(rec => rec.DocumentName == model.DocumentName || rec.Id == model.Id);
            return document != null ? CreateModel(document) : null;
        }
        public void Insert(DocumentBindingModel model)
        {
            int maxId = source.Documents.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Document
            {
                Id = maxId + 1,
                DocumentComponents = new
           Dictionary<int, int>()
            };
            source.Documents.Add(CreateModel(model, element));
        }
        public void Update(DocumentBindingModel model)
        {
            var element = source.Documents.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(DocumentBindingModel model)
        {
            Document element = source.Documents.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Documents.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private Document CreateModel(DocumentBindingModel model, Document document)
        {
            document.DocumentName = model.DocumentName;
            document.Price = model.Price;
            // удаляем убранные
            foreach (var key in document.DocumentComponents.Keys.ToList())
            {
                if (!model.DocumentComponents.ContainsKey(key))
                {
                    document.DocumentComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.DocumentComponents)
            {
                if (document.DocumentComponents.ContainsKey(component.Key))
                {
                    document.DocumentComponents[component.Key] =
                   model.DocumentComponents[component.Key].Item2;
                }
                else
                {
                    document.DocumentComponents.Add(component.Key,
                   model.DocumentComponents[component.Key].Item2);
                }
            }
            return document;
        }
        private DocumentViewModel CreateModel(Document document)
        {
            return new DocumentViewModel
            {
                Id = document.Id,
                DocumentName = document.DocumentName,
                Price = document.Price,
                DocumentComponents = document.DocumentComponents
                    .ToDictionary(recPC => recPC.Key, recPC =>
                        (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}