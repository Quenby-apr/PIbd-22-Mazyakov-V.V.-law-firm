using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmBusinessLogic.ViewModels
{
    public class PageViewModel
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public List<MessageInfoViewModel> Messages { get; set; }
        public int Count { get; set; }
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
