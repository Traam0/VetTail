using System;
using System.Linq;
using System.Collections.Generic;

namespace VetTail.Application.Common.DTOs.Generic;

public class PaginatedList<T> where T : class
{
    public IReadOnlyCollection<T> Items { get; private set; }
    public int PageNumber { get; private set; }
    public int TotalPages { get; private set; }
    public int TotalItems { get; set; }
    public int Size { get; set; }

    private PaginatedList()
    {
        Items = [];
        PageNumber = 1;
        Size = 1;
        TotalPages = 0;
        TotalItems = 0;
    }

    private PaginatedList(IReadOnlyCollection<T> items, int pageNumber, int pageSize, int totalItems) : this()
    {
        Items = items;
        PageNumber = pageNumber;
        TotalItems = totalItems;
        Size = pageSize;
        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

    }


    public static PaginatedList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
    {
        int count = source.Count();
        if (pageNumber < 1) throw new ArgumentException($"minimun allowd page number is one, {pageNumber} was given.");
        if (pageSize < 1) throw new ArgumentException($"minumum allowd page size is one, {pageSize} was given.");

        var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        return new PaginatedList<T>(items, pageNumber, pageSize, count);
    }

    public string Display()
    {
        int start = (PageNumber - 1) * Size + 1;
        int end = Math.Min(PageNumber * Size, TotalItems);

        return $"Showing {start}-{end} of {TotalItems} items";
    }

    public bool HasNextPage => PageNumber < TotalPages;
    public bool HasPrevPage => PageNumber > 1;
}
