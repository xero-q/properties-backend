using System;
using System.Collections.Generic;

namespace Application.Wrappers;

public class Pagination<T>
{
    public Pagination()
    {
    }

    public Pagination(int currentPage, int pageSize, int totalItems, List<T> result)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalItems = totalItems;
        Result = result;
        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
    }
    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public int TotalPages { get; set; }

    public int TotalItems { get; set; }

    public List<T> Result { get; set; }
}