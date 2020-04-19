﻿using System;
using System.Collections.Generic;

namespace ShoppingList.Data { 

    public class PaginatedList<T> : List<T> {

        public int PageIndex  { get; private set; }
        public int PageSize   { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> source, int count, int pageIndex, int pageSize) {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int) Math.Ceiling(TotalCount / (double)PageSize);

            this.AddRange(source);
        }

        public bool HasPreviousPage {
            get {
                return (PageIndex > 0);
            }
        }

        public bool HasNextPage {
            get {
                return (PageIndex+1 < TotalPages);
            }
        }
    }
}