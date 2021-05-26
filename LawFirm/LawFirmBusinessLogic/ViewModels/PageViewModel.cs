using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using LawFirmBusinessLogic.Attributes;

namespace LawFirmBusinessLogic.ViewModels
{
    public class PageViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 100)]
        public int PageNumber { get; set; }
        [DataMember]
        [Column(title: "Всего страниц", width: 100)]
        public int TotalPages { get; set; }
        [DataMember]
        [Column(title: "Список сообщений",visible:false, width: 100)]
        public List<MessageInfoViewModel> Messages { get; set; }
        [DataMember]
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }
        [DataMember]
        [Column(title: "Размер страницы", width: 100)]
        public int PageSize { get; set; }

        public PageViewModel(int count, int pageNumber, int pageSize, List<MessageInfoViewModel> messages)
        {
            PageNumber = pageNumber;
            Count = count;
            Messages = messages;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(Count / (double)pageSize);
        }

        public bool HasPreviousPage
        {
            get { return PageNumber > 1; }
        }

        public bool HasNextPage
        {
            get { return PageNumber < TotalPages; }
        }
    }
}
